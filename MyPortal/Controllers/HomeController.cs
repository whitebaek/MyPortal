using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security.AntiXss;

namespace MyPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var str = AntiXssEncoder.HtmlEncode("username", false); 
            return View();
        }

        // Only Authenticated users can access thier profile
        [Authorize]
        public ActionResult Profile()
        {
            // Instantiate the ASP.NET Identity system
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MyPortalUserDbContext()));
            // Get the current logged in User and look up the user in ASP.NET Identity
            var currentUser = manager.FindById(User.Identity.GetUserId());
            
            // Recover the profile information about the logged in user
            ViewBag.FirstName = currentUser.MyUserInfo.FirstName;
            ViewBag.UserId = currentUser.MyUserInfo.Id;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Board_Create()
        {
            return View();
        }
    }
}