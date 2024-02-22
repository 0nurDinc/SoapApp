using SoapApp.Service.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SoapApp.Service.Context
{
    public class AtmContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public AtmContext():base("name=AtmDB")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasRequired<Customer>(x => x.Customer)
                .WithMany(y => y.Accounts)
                .HasForeignKey(fk => fk.CustomerID);
        }
    }
}