namespace ConfigPC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AudioCard
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

        public short? Interface { get; set; }

        public short? AudioChannels { get; set; }

        public virtual AudioCardType AudioCardType { get; set; }

        public virtual AudioChannel AudioChannel { get; set; }

        public virtual Interface Interface1 { get; set; }
    }
}
