using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Koffee_Hotel.Models;

namespace Koffee_Hotel.Controllers
{
    public class AccountController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if user exists with given email and password
                var user = db.Users.SingleOrDefault(u => u.EmailAddress == model.Email && u.Password == model.Password);

                if (user != null && user.ActiverUser)
                {
                    // User is valid, create authentication cookie and set session
                    FormsAuthentication.SetAuthCookie(user.EmailAddress, false);
                    Session["UserID"] = user.UserID;
                    Session["UserName"] = user.UserName;
                    Session["UserTypeID"] = user.UserTypeID;

                    // Redirect based on user type (optional)
                    if (user.UserTypeID == 1) // Example: Admin
                    {
                        return RedirectToAction("AdminDashboard", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("UserDashboard", "User");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password, or inactive user.");
                }
            }
            return View(model);
        }

        // Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
