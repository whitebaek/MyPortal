using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyPortal.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private MyPortalUserDbContext db = new MyPortalUserDbContext();

        // GET: /User/Details/5
        public ActionResult Details()
        {
            // Instantiate the ASP.NET Identity system
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MyPortalUserDbContext()));
            // Get the current logged in User and look up the user in ASP.NET Identity
            var currentUser = manager.FindById(User.Identity.GetUserId());

            MyUserInfo myuserinfo = db.MyUserInfos.Find(currentUser.MyUserInfo.Id);
            
            if (myuserinfo == null)
            {
                return HttpNotFound();
            }
            return View(myuserinfo);
        }

        // GET: /User/Edit/5
        public ActionResult Edit()
        {
            // Instantiate the ASP.NET Identity system
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MyPortalUserDbContext()));
            // Get the current logged in User and look up the user in ASP.NET Identity
            var currentUser = manager.FindById(User.Identity.GetUserId());

            MyUserInfo myuserinfo = db.MyUserInfos.Find(currentUser.MyUserInfo.Id);
            if (myuserinfo == null)
            {
                return HttpNotFound();
            }
            return View(myuserinfo);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FirstName,LastName")] MyUserInfo myuserinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myuserinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myuserinfo);
        }

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
