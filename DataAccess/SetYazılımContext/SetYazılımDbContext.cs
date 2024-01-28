using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SetYazılımContext
{
    public class SetYazılımDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
               @"Server = (localdb)\MSSQLLocalDB;
                Database = SetYazilim;
                Trusted_Connection = True"
               );
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salary>()
                .Property(s => s.TotalSalary)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Salary>()
                .Property(s => s.DailySalary)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Salary>()
                .Property(s => s.FixedSalary)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Salary>()
                .Property(s => s.OverTimeRate)
                .HasColumnType("decimal(18,2)");

        }
    }
}

