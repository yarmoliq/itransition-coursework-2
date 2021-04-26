using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using DataAccess.Models;


namespace DataAccess.Configuration
{
    public class MyIdentityDataInitializer
    {
        public static async Task SeedUsers(ApplicationDbContext context, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            if (await context.Users.AnyAsync())
                return;

            var user1 = (new AppUser { UserName = "user1", Email = "user1@email.com", FirstName = "Kot", LastName = "Popugaev" });
            await userManager.CreateAsync(user1, "#FoRk1337");
            context.Users.Add(user1);

            var user2 = (new AppUser { UserName = "user2", Email = "user2@email.com", FirstName = "Pes", LastName = "Sharik" });
            await userManager.CreateAsync(user2, "#FoRk1337");
            context.Users.Add(user2);

            var user3 = (new AppUser { UserName = "user3", Email = "user3@email.com", FirstName = "Tim", LastName = "Kooc" });
            await userManager.CreateAsync(user3, "#FoRk1337");
            context.Users.Add(user3);

            var user4 = (new AppUser { UserName = "user4", Email = "user4@email.com", FirstName = "Senior", LastName = "Developer" });
            await userManager.CreateAsync(user4, "#FoRk1337");
            context.Users.Add(user4);

            context.SaveChanges();
        }
    }
}
