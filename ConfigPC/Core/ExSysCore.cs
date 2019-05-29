using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConfigPC.Models;

namespace ConfigPC
{
    class ExSysCore
    {
        HighRange HRange = new HighRange();
        MidRange MRange = new MidRange();
        LowRange LRange = new LowRange();

        public decimal Price;
        public int Purpose;

        public decimal MBPrice, ProcessorPrice, VideocardPrice, RAMPrice, HDPrice, SSDPrice, CoolerPrice, CasePrice, PBPrice;

        public ExSysCore(string price, int purpose)
        {
            Price = Convert.ToDecimal(price);
            Purpose = purpose;
        }        

        public void Build()
        {
            using (ComponentsPC db = new ComponentsPC())
            {
                SetPriceFactors();
                IList resultList = new List<object>();

                ProcessorPrice = GetComponentPrice(ProcessorFactor);
                var processors = db.Processors
                    .Where(p => p.Price < ProcessorPrice * (decimal)1.1)
                    .Where(p => p.Price > ProcessorPrice * (decimal)0.9)
                    .ToList()
                    .GroupBy(p => p.ID)
                    .Select(query => new {
                        MaxCoef = query.Max(p => p.CoreFrequency * p.Cores / (p.TechProcess * 10)),
                        Id = query.Key,                        
                    });
                var processorId = processors.OrderBy(p => p.MaxCoef).Last().Id;
                var processor = db.Processors
                    .Where(p => p.ID == processorId)
                    .Single();
                resultList.Add(new { Component = "Процессор", Title = processor.ProcessorSery.Name + " " + processor.Name, processor.Price, processor.Source });

                MBPrice = GetComponentPrice(MBFactor);
                var motherboards = processor.Socket1.Motherboards
                    .Where(p => p.Price < MBPrice*(decimal)1.1)
                    .Where(p => p.Price > MBPrice * (decimal)0.5)
                    .ToList()
                    .GroupBy(p => p.ID)
                    .Select(query => new {
                        MaxCoef = query.Max(p => p.MaxCapacity * p.MaxFrequency/10 + p.SATA3*10 + p.M2connector*10 + p.PCIE1xSlots*10 + p.PCIE16xSlots*10),
                        Id = query.Key,
                    });
                var motherboardId = motherboards.OrderBy(p => p.MaxCoef).Last().Id;
                var motheboard = processor.Socket1.Motherboards
                    .Where(p => p.ID == motherboardId)
                    .Single();
                resultList.Add(new { Component = "Материнская плата", Title = motheboard.Name, motheboard.Price, motheboard.Source });

                if (VideocardFactor != 0f)
                {
                    VideocardPrice = GetComponentPrice(VideocardFactor);
                    var videocards = db.Videocards
                        .Where(p => p.Price < VideocardPrice * (decimal)1.1)
                        .Where(p => p.Price > VideocardPrice * (decimal)0.9)
                        .ToList()
                        .GroupBy(p => p.ID)
                        .Select(query => new {
                            MaxCoef = query.Max(p => (p.BusWidth*10 + p.GPUFrequency + p.MemoryFrequency*p.MemoryCapacity / 10)/p.Techprocess),
                            Id = query.Key,
                        });
                    var videacardId = videocards.OrderBy(p => p.MaxCoef).Last().Id;
                    var videocard = db.Videocards
                        .Where(p => p.ID == videacardId)
                        .Single();
                    resultList.Add(new { Component = "Видеокарта", Title = videocard.Name, videocard.Price, videocard.Source });

                }

                RAMPrice = GetComponentPrice(RAMFactor);
                var RAMs = motheboard.MemoryType1.RAMs
                    .Where(p => p.Price < RAMPrice * (decimal)1.1)
                    .Where(p => p.Price > RAMPrice * (decimal)0.5)
                    .ToList()
                    .GroupBy(p => p.ID)
                    .Select(query => new {
                        MaxCoef = query.Max(p => (p.Frequency * p.Speed / (p.Timing1))),
                        Id = query.Key,
                    });
                var RAMId = RAMs.OrderBy(p => p.MaxCoef).Last().Id;
                var RAM = db.RAMs
                    .Where(p => p.ID == RAMId)
                    .Single();
                resultList.Add(new { Component = "ОЗУ", Title = RAM.Name, RAM.Price, RAM.Source });

                HDPrice = GetComponentPrice(HDFactor);
                var HardDrives = db.HardDrives
                    .Where(p => p.Price < HDPrice * (decimal)1.1)
                    .Where(p => p.Price > HDPrice * (decimal)0.9)
                    .ToList();

                if (SSDFactor != 0f)
                {
                    SSDPrice = GetComponentPrice(SSDFactor);
                    var SSDDrives = db.SSDDrives
                    .Where(p => p.Price < SSDPrice * (decimal)1.1)
                    .Where(p => p.Price > SSDPrice * (decimal)0.9)
                    .ToList();
                }

                CoolerPrice = GetComponentPrice(CoolerFactor);
                var Coolers = processor.Socket1.CoolerCompatibilities
                    .Select(p => p.Cooler)
                    .Where(p => p.Price < CoolerPrice * (decimal)1.1)
                    .Where(p => p.Price > CoolerPrice * (decimal)0.9)
                    .ToList()
                    .GroupBy(p => p.ID)
                    .Select(query => new {
                        MaxCoef = query.Max(p => (p.FanDiameter * p.FanSpeed)),
                        Id = query.Key,
                    });
                var coolerId = Coolers.OrderBy(p => p.MaxCoef).Last().Id;
                var cooler = db.Coolers
                    .Where(p => p.ID == coolerId)
                    .Single();
                resultList.Add(new { Component = "Охлаждение процессора", Title = cooler.Name, cooler.Price, cooler.Source });

                CasePrice = GetComponentPrice(CaseFactor);
                var Cases = db.Cases
                    .Where(p => p.Price < CasePrice * (decimal)1.1)
                    .Where(p => p.Price > CasePrice * (decimal)0.9)
                    .ToList();

                PBPrice = GetComponentPrice(PBFactor);
                var PowerBlocks = db.PowerBlocks
                    .Where(p => p.Price < PBPrice * (decimal)1.1)
                    .Where(p => p.Price > PBPrice * (decimal)0.9)
                    .ToList();
                ResultWindow result = new ResultWindow();
                result.resultGrid.ItemsSource = resultList;
                
                result.Show();
            }
        }

        public string GetPriceType()
        {
            float HFactor = HRange.GetEntryFactor(Price);
            float MFactor = MRange.GetEntryFactor(Price);
            float LFactor = LRange.GetEntryFactor(Price);
            if (MFactor >= HFactor && MFactor >= LFactor)
            {
                return "Middle";
            }
            else
            if (HFactor > MFactor && HFactor > LFactor)
            {
                return "High";
            }
            else
            if (LFactor > MFactor && LFactor > HFactor)
            {
                return "Low";
            }
            else
                return null;
        }
        
        public float MBFactor = 0.1f, ProcessorFactor = 0.15f, VideocardFactor = 0.2f, RAMFactor = 0.1f, HDFactor = 0.1f, SSDFactor = 0.1f, CoolerFactor = 0.1f, CaseFactor = 0.05f, PBFactor = 0.1f;

        public void SetPriceFactors()
        {
            if (Purpose == 0)
            {
                MBFactor = 0.1f;
                ProcessorFactor = 0.2f;
                VideocardFactor = 0.2f;
                RAMFactor = 0.1f;
                HDFactor = 0.15f;
                SSDFactor = 0.1f;
                CoolerFactor = 0.05f;
                CaseFactor = 0.05f;
                PBFactor = 0.05f;
            }
            if (Purpose == 1)
            {
                MBFactor = 0.14f;
                ProcessorFactor = 0.18f;
                VideocardFactor = 0.18f;
                RAMFactor = 0.1f;
                HDFactor = 0.1f;
                SSDFactor = 0.1f;
                CoolerFactor = 0.1f;
                CaseFactor = 0.05f;
                PBFactor = 0.05f;
            }
            if (Purpose == 2)
            {
                MBFactor = 0.1f;
                ProcessorFactor = 0.25f;
                VideocardFactor = 0.05f;
                RAMFactor = 0.15f;
                HDFactor = 0.15f;
                SSDFactor = 0.15f;
                CoolerFactor = 0.05f;
                CaseFactor = 0.05f;
                PBFactor = 0.05f;
            }
            if (Purpose == 3)
            {
                MBFactor = 0.1f;
                ProcessorFactor = 0.2f;
                VideocardFactor = 0.05f;
                RAMFactor = 0.1f;
                HDFactor = 0.15f;
                SSDFactor = 0.1f;
                CoolerFactor = 0.05f;
                CaseFactor = 0.05f;
                PBFactor = 0.05f;
            }
            if (Purpose == 4)
            {
                MBFactor = 0.15f;
                ProcessorFactor = 0.25f;
                VideocardFactor = 0f;
                RAMFactor = 0.2f;
                HDFactor = 0.25f;
                SSDFactor = 0f;
                CoolerFactor = 0.05f;
                CaseFactor = 0.05f;
                PBFactor = 0.05f;
            }
        }

        public decimal GetComponentPrice(float Factor)
        {
            return Price * (decimal)Factor;
        }
    }
}