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
    
    public partial class SSDDrive
    {
        public short ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Source { get; set; }
        public Nullable<short> Type { get; set; }
        public Nullable<byte> Capacity { get; set; }
        public Nullable<short> MemoryType { get; set; }
        public Nullable<short> FormFactor { get; set; }
        public Nullable<short> Interface { get; set; }
        public Nullable<byte> BuferCapacity { get; set; }
        public Nullable<byte> SpeedWrite { get; set; }
        public Nullable<byte> SpeedRead { get; set; }
    
        public virtual FormFactorsD FormFactorsD { get; set; }
        public virtual FormFactorsHD FormFactorsHD { get; set; }
        public virtual HDMemoryType HDMemoryType { get; set; }
        public virtual Interface Interface1 { get; set; }
    }
}
