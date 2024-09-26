namespace Koffee_Hotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parking")]
    public partial class Parking
    {
        public int ParkingID { get; set; }

        public int ReservationID { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
