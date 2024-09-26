namespace Koffee_Hotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Setting
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemType { get; set; }

        public int Count { get; set; }
    }
}
