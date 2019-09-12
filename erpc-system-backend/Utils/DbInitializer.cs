using erpc_system_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Utils
{
    public class DbInitializer
    {
        public static void Initialize(ErpcDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Accounts.Any())
            {
                return;
            }

            //Create a plan
            Plan plan = new Plan
            {
                Name = "BusinessA",
                Feautures = "Full-features"
            };

            context.Plans.Add(plan);
            context.SaveChanges();

            string HashedPassword = Hasher.GetHash("admin1");

            //Create user
            User user = new User
            {
                Name = "Maykol Laguna",
                Email = "testing@tuturulabs.com",
                HashedPassword = HashedPassword   
            };

            context.Users.Add(user);
            context.SaveChanges();

            //Create an account
            Account account = new Account
            {
                Features = "Full",
                Plan = plan,
                SubscriptionId = 1000
            };

            context.Accounts.Add(account);
            context.SaveChanges();

            //Create membership
            Membership membership = new Membership
            {
                Access = "admin",
                Account = account,
                User = user
            };

            context.Memberships.Add(membership);
            context.SaveChanges();
            
        }
    }
}
