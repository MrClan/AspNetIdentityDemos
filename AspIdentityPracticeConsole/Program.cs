using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace AspIdentityPracticeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext ctx = new IdentityDbContext("DefaultConnectionString");
            //ctx.Database.Connection.Open();



            var username = "mrclan";
            var password = "apple_mango4321";

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            var creationResult = userManager.Create(new IdentityUser(username), password);
            Console.WriteLine($"{creationResult.Succeeded}. {creationResult.Errors.Aggregate("Reason: ",(e, f) => e + f)}");
            Console.ReadKey();
        }
    }
}

