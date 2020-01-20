namespace MovieX.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MovieX.Models;
    using System;
    using System.Data.Entity;
    
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieX.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieX.Models.ApplicationDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var role = new IdentityRole { Name = "User" };
                manager.Create(role);
            }

            if (!context.Users.Any(user => user.UserName == "admin1@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin1@gmail.com",
                    Email = "admin1@gmail.com",
                    BirthDate = new DateTime(1990,1,1),
                    Gender = Models.Enums.Gender.Male,
                    Country = Models.Enums.Country.Greece,
                    Password="Admin123$",
                    FirstName = "Admin",
                    LastName = "Admin"
                };

                var result = userManager.Create(user, "Admin123$");

                if (result.Succeeded)
                {
                    var admin = context.Users.SingleOrDefault(i => i.UserName == "admin1@gmail.com");
                    userManager.AddToRoles(admin.Id, "Admin");
                }
            }
            if (!context.Users.Any(user => user.UserName == "admin2@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin2@gmail.com",
                    Email = "admin2@gmail.com",
                    BirthDate = new DateTime(1980, 1, 5),
                    Gender = Models.Enums.Gender.Male,
                    Country = Models.Enums.Country.Greece,
                    Password = "Admin123$",
                    FirstName = "Admin",
                    LastName = "Admin"
                };

                var result = userManager.Create(user, "Admin123$");

                if (result.Succeeded)
                {
                    var admin = context.Users.SingleOrDefault(i => i.UserName == "admin2@gmail.com");
                    userManager.AddToRoles(admin.Id, "Admin");
                }
            }
            if (!context.Users.Any(user => user.UserName == "admin3@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin3@gmail.com",
                    Email = "admin3@gmail.com",
                    BirthDate = new DateTime(1978, 5, 22),
                    Gender = Models.Enums.Gender.Male,
                    Country = Models.Enums.Country.Greece,
                    Password = "Admin123$",
                    FirstName = "Admin",
                    LastName = "Admin"
                };

                var result = userManager.Create(user, "Admin123$");

                if (result.Succeeded)
                {
                    var admin = context.Users.SingleOrDefault(i => i.UserName == "admin3@gmail.com");
                    userManager.AddToRoles(admin.Id, "Admin");
                }
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
