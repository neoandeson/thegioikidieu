using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    //nuget Microsoft.EntityFrameworkCore
    public class DisneyDB : DbContext
    {
        public DisneyDB(DbContextOptions<DisneyDB> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //nuget Microsoft.EntityFrameworkCore.SqlServer
            //optionsBuilder.UseSqlServer("server=.;database=Disney;trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .Property(b => b.RecordStatus)
                .HasDefaultValue(1);
            //1: active, -1: delete, 0 deactive

            modelBuilder.Entity<Transaction>()
                .Property(b => b.RecordStatus)
                .HasDefaultValue(1);
            //1: active, -1: delete, 0 deactive
        }

        //Microsoft.EntityFrameworkCore.Tools
        //Microsoft.EntityFrameworkCore.Design
        //Run command
        //Add-Migration Initial
        //Update-Database
    }
}
