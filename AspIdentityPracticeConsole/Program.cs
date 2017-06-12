using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;

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


            // Create new user
            var creationResult = userManager.Create(new IdentityUser(username), password);
            Console.WriteLine($"{creationResult.Succeeded}. {creationResult.Errors.Aggregate("Reason: ",(e, f) => e + f)}");

            // Get user to get user's id and other properties
            var user = userManager.FindByName(username);

            // Remove claim
            var removeClaimResult = userManager.RemoveClaim(user.Id, new Claim("given_name", "MrClan"));

            // Create new claim for the user
            var claimResult = userManager.AddClaim(user.Id, new Claim("given_name", "MrClan"));
            Console.WriteLine($"Claim: {claimResult.Succeeded}");
            
            // verify user password
            var isMatch = userManager.CheckPassword(user, password);
            Console.WriteLine($"Password Matches: {isMatch}");

            Console.ReadKey();
        }
    }
}

