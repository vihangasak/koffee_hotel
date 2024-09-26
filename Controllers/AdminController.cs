using System;
using System.Linq;
using System.Web.Mvc;
using Koffee_Hotel.Models;

namespace Koffee_Hotel.Controllers
{
    [Authorize(Roles = "Admin")] // Ensure only users with Admin role can access
    public class AdminController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: AdminDashboard
        public ActionResult AdminDashboard()
        {
            // Retrieve summary data for the dashboard
            ViewBag.TotalUsers = db.Users.Count();
            ViewBag.TotalReservations = db.Reservations.Count();
            ViewBag.TotalOrders = db.Orders.Count();

            // Get recent registrations (last 5 users)
            ViewBag.RecentUsers = db.Users.OrderByDescending(u => u.CreateDateTime).Take(5).ToList();

            // Get recent reservations (last 5 reservations)
            ViewBag.RecentReservations = db.Reservations.OrderByDescending(r => r.ReservationDate).Take(5).ToList();

            // You can add more data retrieval as needed

            return View();
        }

        // Add other admin-related actions here
        // For example: User management, Reservation management, Reports, etc.

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}