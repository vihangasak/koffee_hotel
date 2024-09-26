namespace Koffee_Hotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catergory")]
    public partial class Catergory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catergory()
        {
            FoodItems = new HashSet<FoodItem>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CatergoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public virtual Catergory Catergory1 { get; set; }

        public virtual Catergory Catergory2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FoodItem> FoodItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
