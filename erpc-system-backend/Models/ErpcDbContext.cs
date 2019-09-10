using erpc_system_backend.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class ErpcDbContext : DbContext
    {
        #region Entities

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }

        #endregion



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(ConnectionString.Get());


        /*
         * TODO:
         * TODO:
         * 
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membership>().HasKey(sc => new { sc.AccountId, sc.UserId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
