using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using ClassLibrary1.Models;


namespace ClassLibrary1.Configuration
{
    public class MyIdentityDataInitializer
    {
        public static void SeedUsers(ApplicationDbContext context, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            var u1 = new AppUser();
            u1.FirstName = "First Name";
            u1.LastName = "Last Name";
            userManager.CreateAsync(u1);

            context.Users.Add(u1);
            context.SaveChanges();
        }
    }
}
