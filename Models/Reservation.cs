namespace Koffee_Hotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservation()
        {
            Orders = new HashSet<Order>();
            Parkings = new HashSet<Parking>();
        }

        public int ReservationID { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReservationDate { get; set; }

        public TimeSpan ReservationTimeFrom { get; set; }

        public TimeSpan ReservationTimeTo { get; set; }

        public int NoGuests { get; set; }

        public int StatusID { get; set; }

        public DateTime CreateDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parking> Parkings { get; set; }

        public virtual Status Status { get; set; }

        public virtual User User { get; set; }
    }
}
