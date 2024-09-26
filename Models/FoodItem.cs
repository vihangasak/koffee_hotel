namespace Koffee_Hotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FoodItem")]
    public partial class FoodItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FoodItem()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FoodID { get; set; }

        [Required]
        [StringLength(150)]
        public string FoodName { get; set; }

        public double Price { get; set; }

        [Required]
        [StringLength(350)]
        public string Description { get; set; }

        public int CatergoryID { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BalanceQty { get; set; }

        public virtual Catergory Catergory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
