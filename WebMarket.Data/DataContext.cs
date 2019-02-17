using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using WebMarket.Data.Entities.Security;

namespace WebMarket.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Entities.Security.UserDB> Users { get; set; }
        public DbSet<Entities.Security.RoleDB> Roles { get; set; }

        public DataContext() : base("MyConnectionDB")
        {
            this.Database.CreateIfNotExists();
        }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDB>()
                .HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .Map(x =>
                {
                    x.MapLeftKey("UserId");
                    x.MapRightKey("RoleId");
                    x.ToTable("UserRole");
                });
        }
    }
}
