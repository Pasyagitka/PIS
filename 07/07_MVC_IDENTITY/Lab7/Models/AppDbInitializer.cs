using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class AppDbInitializer: DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var r_administrator = new IdentityRole { Name = "Administrator" };
            var r_employer = new IdentityRole { Name = "Employer" };
            var r_guest = new IdentityRole { Name = "Guest" };

            var userAdmin = new ApplicationUser { Email = "admin@belstu.by", UserName = "admin@belstu.by" };
            var userEmployer = new ApplicationUser { Email = "emp@belstu.by", UserName = "emp@belstu.by" };
            var userGuest = new ApplicationUser { Email = "guest@belstu.by", UserName = "guest@belstu.by" };
            var userV = new ApplicationUser { Email = "super@belstu.by", UserName = "super@belstu.by" };

            var b_administrator = roleManager.Create(r_administrator).Succeeded;
            var b_employer = roleManager.Create(r_employer).Succeeded;
            var b_guest = roleManager.Create(r_guest).Succeeded;

            var b_Admin = userManager.Create(userAdmin, "userAdmin").Succeeded;
            var b_Employer = userManager.Create(userEmployer, "userEmployer").Succeeded;
            var b_Guest= userManager.Create(userGuest, "userGuest").Succeeded;
            var b_All = userManager.Create(userV, "userVipVip").Succeeded;

            if(b_administrator && b_Admin)
            {
                userManager.AddToRole(userAdmin.Id, r_administrator.Name);
            }

            if (b_employer && b_Employer)
            {
                userManager.AddToRole(userEmployer.Id, r_employer.Name);
            }

            if (b_guest && b_Guest)
            {
                userManager.AddToRole(userGuest.Id, r_guest.Name);
            }

            if(b_All && b_administrator && b_employer && b_guest)
            {
                userManager.AddToRoles(userV.Id, r_guest.Name, r_employer.Name, r_administrator.Name);
            }

            base.Seed(context);
        }
    }
}