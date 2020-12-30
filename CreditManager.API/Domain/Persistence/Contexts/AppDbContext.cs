using CreditManager.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetails> TransactionDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Profile Entity
            builder.Entity<Profile>().ToTable("Profiles").HasKey(p => p.Id);
            builder.Entity<Profile>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profile>().Property(p => p.FirstName).HasMaxLength(30);
            builder.Entity<Profile>().Property(p => p.LastName).HasMaxLength(30);
            builder.Entity<Profile>().Property(p => p.CompanyName).HasMaxLength(30);
            builder.Entity<Profile>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
            builder.Entity<Profile>().Property(p => p.RegisterDate).IsRequired();
            builder.Entity<Profile>().Property(p => p.UserType).IsRequired();
            builder.Entity<Profile>().Property(p => p.UserType).HasConversion<string>();
            builder.Entity<Profile>().Property(p => p.ImageUrl).HasMaxLength(255);
            builder.Entity<Profile>()
                .HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<User>(u => u.ProfileId);
            builder.Entity<Profile>().HasData(
                new Profile { Id = 1, FirstName = "Arthur", LastName="Valladares", RegisterDate = DateTime.Now, Phone = "9265345", UserType = EUserType.Customer},
                new Profile { Id = 2, CompanyName = "Tienda Don Pepe", RegisterDate = DateTime.Now, Phone = "92745245", UserType = EUserType.OwnerCompany }
                );
            #endregion

            #region User Entity
            builder.Entity<User>().ToTable("Users").HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(30);
            builder.Entity<User>()
                .HasMany(u => u.CustomerAccounts)
                .WithOne(a => a.Owner)
                .HasForeignKey(a => a.OwnerId);
            builder.Entity<User>()
                .HasMany(u => u.CompanyAccounts)
                .WithOne(a => a.Company)
                .HasForeignKey(a => a.CompanyId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<User>().HasData(
                    new User { Id = 1, Email = "arthur1610@live.com", Password = "123", ProfileId = 1},
                    new User { Id = 2, Email = "pepe@gmail.com", Password="123", ProfileId=2}
                );
            #endregion

            #region Account Entity
            builder.Entity<Account>().ToTable("Accounts").HasKey(a => a.AccountNumber);
            builder.Entity<Account>().Property(a => a.AccountNumber).IsRequired().HasMaxLength(11);
            builder.Entity<Account>().Property(a => a.AvailableMoney).IsRequired();
            builder.Entity<Account>().Property(a => a.Currency).IsRequired().HasMaxLength(10);
            builder.Entity<Account>().Property(a => a.Currency).HasConversion<string>();
            builder.Entity<Account>().Property(a => a.TypeOfInterest).HasMaxLength(15);
            builder.Entity<Account>().Property(a => a.TypeOfInterest).HasConversion<string>();
            builder.Entity<Account>().Property(a => a.DateOfLastPayment).IsRequired();
            builder.Entity<Account>()
                .HasMany(a => a.Transactions)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountNumber);
            builder.Entity<Account>().HasData(
                    new Account { AccountNumber="123456789", AvailableMoney = 500, CompanyId = 2, Currency = ECurrency.Soles, 
                        DateOfLastPayment = DateTime.Now, OwnerId = 1, RateInterest = 3, TypeOfInterest = ETypeOfInterest.Efectivo }
                );
            #endregion

            #region Transaction Entity
            builder.Entity<Transaction>().ToTable("Transactions").HasKey(t => t.Id);
            builder.Entity<Transaction>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Transaction>().Property(t => t.TotalAmount).IsRequired();
            builder.Entity<Transaction>().Property(t => t.Type).IsRequired().HasMaxLength(1);
            builder.Entity<Transaction>().Property(t => t.Date).IsRequired();
            builder.Entity<Transaction>()
                .HasMany(t => t.TransactionDetails)
                .WithOne(td => td.Transaction)
                .HasForeignKey(td => td.TransactionId);
            // TODO: falta ver que cuando se agrege un movimiento, se modifique el saldo y la deuda, esto se haria en el Service
            #endregion

            #region TransactionDetail Entity
            builder.Entity<TransactionDetails>().ToTable("TransactionsDetails").HasKey(t => t.Id);
            builder.Entity<TransactionDetails>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TransactionDetails>().Property(t => t.Name).HasMaxLength(50);
            builder.Entity<TransactionDetails>().Property(t => t.Description).HasMaxLength(200);
            #endregion
        }
    }
}
