namespace ConfigPC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HardDrive
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ID { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Source { get; set; }

        public short? Type { get; set; }

        public short? MemoryType { get; set; }

        public short? Interface { get; set; }

        public byte? Capacity { get; set; }

        public short? FormFactor { get; set; }

        public byte? BuferCapacity { get; set; }

        public byte? Speed { get; set; }

        public virtual FormFactorD FormFactorsD { get; set; }

        public virtual FormFactorHD FormFactorsHD { get; set; }

        public virtual HDMemoryType HDMemoryType { get; set; }

        public virtual Interface Interface1 { get; set; }
    }
}
