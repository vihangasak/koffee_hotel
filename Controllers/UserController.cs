using System;
using System.Web.Mvc;
using Koffee_Hotel.Models;

namespace Koffee_Hotel.Controllers
{
    [Authorize] // This attribute ensures that only authenticated users can access these actions
    public class UserController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: UserDashboard
        public ActionResult UserDashboard()
        {
            // Retrieve the current user's ID from the session
            int userId = (int)Session["UserID"];

            // Fetch the user from the database
            var user = db.Users.Find(userId);

            if (user == null)
            {
                return HttpNotFound();
            }

            // You can pass the user object to the view to display user-specific information
            return View(user);
        }

        // Add other user-related actions here as needed
    }
}