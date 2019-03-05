namespace ConfigPC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RAM")]
    public partial class RAM
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

        public byte Capacity { get; set; }

        public byte PlanksCount { get; set; }

        public short MemoryType { get; set; }

        public short FormFactor { get; set; }

        public byte? Frequency { get; set; }

        public byte? Speed { get; set; }

        public byte? Timing1 { get; set; }

        public byte? Timing2 { get; set; }

        public byte? Timing3 { get; set; }

        public byte? Timing4 { get; set; }

        public virtual FormFactorM FormFactorsM { get; set; }

        public virtual MemoryType MemoryType1 { get; set; }
    }
}
