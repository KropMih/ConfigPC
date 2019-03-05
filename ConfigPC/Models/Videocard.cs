namespace ConfigPC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Videocard
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

        public short GPUModel { get; set; }

        public byte MemoryCapacity { get; set; }

        public short MemoryType { get; set; }

        public byte? BusWidth { get; set; }

        public byte GPUFrequency { get; set; }

        public byte MemoryFrequency { get; set; }

        public byte? Techprocess { get; set; }

        public int MaxResolution { get; set; }

        public byte HDMI { get; set; }

        public byte DisplayPort { get; set; }

        public short? DirectX { get; set; }

        public short? OpenGL { get; set; }

        public byte RecPB { get; set; }

        public byte ExpantionSlots { get; set; }

        public byte Length { get; set; }

        public virtual DirectXVersion DirectXVersion { get; set; }

        public virtual GPUModel GPUModel1 { get; set; }

        public virtual MemoryType MemoryType1 { get; set; }

        public virtual OpenGLVersion OpenGLVersion { get; set; }
    }
}
