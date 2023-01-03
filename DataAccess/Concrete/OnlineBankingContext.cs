 using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class OnlineBankingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=OnlineBankingDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAccount>()
                .HasOne<Customer>(a => a.Customer)
                .WithMany(c => c.CustomerAccounts)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<CustomerContactInformation>()
                .HasOne<Customer>(i => i.Customer)
                .WithMany(c => c.CustomerContactInformations)
                .HasForeignKey(i => i.CustomerId);

            modelBuilder.Entity<CustomerRegistryInformation>()
                .HasOne<Customer>(r => r.Customer)
                .WithMany(c => c.CustomerRegistryInformations)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<CustomerOperationClaim>()
                .HasOne<Customer>(r => r.Customer)
                .WithMany(c => c.CustomerOperationClaims)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<OperationClaim>()
                .HasMany<CustomerOperationClaim>(c => c.CustomerOperationClaims)
                .WithOne(o => o.OperationClaim)
                .HasForeignKey(c => c.OperationClaimId);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerContactInformation> CustomerContactInformations { get; set; }
        public DbSet<CustomerRegistryInformation> CustomerRegistryInformations { get; set; }
        public DbSet<CustomerOperationClaim> CustomerOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
    }
}
