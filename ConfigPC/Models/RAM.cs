//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConfigPC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RAM
    {
        public short ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Source { get; set; }
        public byte Capacity { get; set; }
        public byte PlanksCount { get; set; }
        public short MemoryType { get; set; }
        public short FormFactor { get; set; }
        public Nullable<short> Frequency { get; set; }
        public Nullable<int> Speed { get; set; }
        public Nullable<byte> Timing1 { get; set; }
        public Nullable<byte> Timing2 { get; set; }
        public Nullable<byte> Timing3 { get; set; }
        public Nullable<byte> Timing4 { get; set; }
    
        public virtual FormFactorsM FormFactorsM { get; set; }
        public virtual MemoryType MemoryType1 { get; set; }
    }
}
