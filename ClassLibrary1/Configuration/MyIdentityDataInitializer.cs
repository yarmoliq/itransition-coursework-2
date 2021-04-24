using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using ClassLibrary1.Models;


namespace ClassLibrary1.Configuration
{
    public class MyIdentityDataInitializer
    {
        public static async Task SeedUsers(ApplicationDbContext context, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            if (await context.Users.AnyAsync())
                return;

            var user1 = (new AppUser { FirstName = "Kot", LastName = "Popugaev" });
            await userManager.CreateAsync(user1);
            context.Users.Add(user1);

            var user2 = (new AppUser { FirstName = "Pes", LastName = "Sharik" });
            await userManager.CreateAsync(user2);
            context.Users.Add(user2);

            var user3 = (new AppUser { FirstName = "Tim", LastName = "Kooc" });
            await userManager.CreateAsync(user3);
            context.Users.Add(user3);

            var user4 = (new AppUser { FirstName = "Senior", LastName = "Developer" });
            await userManager.CreateAsync(user4);
            context.Users.Add(user4);

            context.SaveChanges();
        }
    }
}
