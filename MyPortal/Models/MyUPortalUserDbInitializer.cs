using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyPortal.Models
{
    // This is useful if you do not want to tear down the database each time you run the application.
    // You want to create a new database if the Model changes
    //public class MyDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    public class MyUPortalUserDbInitializer : DropCreateDatabaseAlways<MyPortalUserDbContext>
    {
        protected override void Seed(MyPortalUserDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        private void InitializeIdentityForEF(MyPortalUserDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            var myinfo = new MyUserInfo() { FirstName = "Michael", LastName = "Baek" };
            
            string adminRoleName = "Admin";
            string password = "123456";
            string generalRoleName = "Level1";

            //Create Role Test and User Test
            RoleManager.Create(new IdentityRole(generalRoleName));
            UserManager.Create(new ApplicationUser() { UserName = "tester" }, password);

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(adminRoleName))
            {
                var roleresult = RoleManager.Create(new IdentityRole(adminRoleName));
            }

            //Create User=Admin with password=123456
            var user = new ApplicationUser();
            user.UserName = "admin";
            user.MyUserInfo = myinfo;
            var adminresult = UserManager.Create(user, password);

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, adminRoleName);
            }


        }
    }
}