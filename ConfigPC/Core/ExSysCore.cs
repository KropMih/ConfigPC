using System;
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

        public object Build()
        {
            using (ComponentsPC db = new ComponentsPC())
            {
                SetPriceFactors();

                ProcessorPrice = GetComponentPrice(ProcessorFactor);
                var processors = db.Processors.Where(p => p.Price < ProcessorPrice*(decimal)1.1).ToList();

                MBPrice = GetComponentPrice(MBFactor);
                var motherboards = db.Motherboards;

                if (VideocardFactor != 0f)
                {
                    VideocardPrice = GetComponentPrice(VideocardFactor);
                    var videocards = db.Videocards;
                }

                RAMPrice = GetComponentPrice(RAMFactor);
                var RAMs = db.RAMs;

                HDPrice = GetComponentPrice(HDFactor);
                var HardDrives = db.HardDrives;

                if (VideocardFactor != 0f)
                {
                    SSDPrice = GetComponentPrice(SSDFactor);
                    var SSDDrives = db.SSDDrives;
                }

                CoolerPrice = GetComponentPrice(CoolerFactor);
                var Cooelers = db.Coolers;

                CasePrice = GetComponentPrice(CaseFactor);
                var Cases = db.Cases;

                PBPrice = GetComponentPrice(PBFactor);
                var PowerBlocks = db.PowerBlocks;

                return processors;
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