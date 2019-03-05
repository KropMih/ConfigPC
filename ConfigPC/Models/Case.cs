namespace ConfigPC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Case
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

        public short? Place { get; set; }

        public short? FormFactor { get; set; }

        public short MBtype { get; set; }

        public byte? PowerBlock { get; set; }

        public byte? Count525 { get; set; }

        public byte? Count35 { get; set; }

        public byte? Count25 { get; set; }

        public byte? ExpantionSlots { get; set; }

        public byte? Fans { get; set; }

        public byte? FanPlaces { get; set; }

        public virtual CasePlace CasePlace { get; set; }

        public virtual FormFactorC FormFactorsC { get; set; }

        public virtual FormFactorMB FormFactorsMB { get; set; }
    }
}
