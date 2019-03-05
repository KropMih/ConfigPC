namespace ConfigPC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CoolerCompatibility")]
    public partial class CoolerCompatibility
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ID { get; set; }

        public short? CoolerID { get; set; }

        public short? SocketID { get; set; }

        public virtual Cooler Cooler { get; set; }

        public virtual Socket Socket { get; set; }
    }
}
