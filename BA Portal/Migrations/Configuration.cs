namespace BA_Portal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using BA_Portal.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BA_Portal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        bool AddUserAndRole(BA_Portal.Models.ApplicationDbContext context)
        {
            //adds can edit role, and admin user using application dbcontext
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("CanView"));
            ir = rm.Create(new IdentityRole("CanEdit"));
            ir = rm.Create(new IdentityRole("CanManageUsers"));
            ir = rm.Create(new IdentityRole("Guest"));
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser() { UserName = "Guest@BAportal.com", };

            //create new user with username and password using usermanager and add to app dbcontext
            ir = um.Create(user, "Guest1!");
            if (ir.Succeeded == false)
                return ir.Succeeded;

            ir = um.AddToRole(user.Id, "CanView");
            ir = um.AddToRole(user.Id, "Guest");
            return ir.Succeeded;
        }

        protected override void Seed(BA_Portal.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            AddUserAndRole(context);

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
