using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.Concrete.Context
{
  public  class ChallengeProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-E1T0HQ2; initial catalog=Challenge; integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(p => p.Manager)
                .WithMany(m => m.Employees)
                .HasForeignKey(f => f.ManagerId);
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
