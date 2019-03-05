namespace ConfigPC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PowerBlock
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

        public byte Power { get; set; }

        public short? FormFactor { get; set; }

        [Column(TypeName = "ntext")]
        public string Sercificate { get; set; }

        public byte? SATAPower { get; set; }

        public byte? MolexPower { get; set; }

        public byte? PCIE8pinPower { get; set; }

        public virtual FormFactorPB FormFactorsPB { get; set; }
    }
}
