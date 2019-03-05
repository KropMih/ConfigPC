namespace ConfigPC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Motherboard
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

        public short Socket { get; set; }

        public short FormFactor { get; set; }

        public short Chipset { get; set; }

        public short MemoryType { get; set; }

        public short MemoryFormFactor { get; set; }

        public short MemoryChannels { get; set; }

        public int? MaxFrequency { get; set; }

        public int? MaxCapacity { get; set; }

        [Column(TypeName = "ntext")]
        public string AudioChip { get; set; }

        public short? AudioChannels { get; set; }

        public byte SATA3 { get; set; }

        public byte M2connector { get; set; }

        public short M2interface { get; set; }

        public byte PCIE1xSlots { get; set; }

        public byte PCIE16xSlots { get; set; }

        public short PCIE30 { get; set; }

        public virtual AudioChannel AudioChannel { get; set; }

        public virtual Chipset Chipset1 { get; set; }

        public virtual FormFactorM FormFactorsM { get; set; }

        public virtual FormFactorMB FormFactorsMB { get; set; }

        public virtual Interface Interface { get; set; }

        public virtual MemoryType MemoryType1 { get; set; }

        public virtual PCIE3Support PCIE3Support { get; set; }

        public virtual Socket Socket1 { get; set; }
    }
}
