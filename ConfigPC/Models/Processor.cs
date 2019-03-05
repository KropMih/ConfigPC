namespace ConfigPC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Processor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Source { get; set; }

        public short? Series { get; set; }

        public short? CodeName { get; set; }

        public short? Socket { get; set; }

        public byte? Cores { get; set; }

        public byte? CoreFrequency { get; set; }

        public byte? TurboBoost { get; set; }

        public byte? TechProcess { get; set; }

        public byte? L1 { get; set; }

        public byte? L2 { get; set; }

        public byte? L3 { get; set; }

        public byte? TDP { get; set; }

        public short? Multiplier { get; set; }

        public virtual CodeName CodeName1 { get; set; }

        public virtual MultiplierStatu MultiplierStatu { get; set; }

        public virtual ProcessorSery ProcessorSery { get; set; }

        public virtual Socket Socket1 { get; set; }
    }
}
