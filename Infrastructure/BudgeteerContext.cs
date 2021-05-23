using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sf.Budgeteer.ApplicationCore.Entities;
using Sf.Budgeteer.ApplicationCore.Entities.BudgetAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sf.Budgeteer.Infrastructure
{
    public class BudgeteerContext : DbContext
    {
        public BudgeteerContext(DbContextOptions<BudgeteerContext> options) : base(options)
        { }

        public DbSet<Budget> Budgets { get; set; }

        public DbSet<BudgetDetail> BudgetDetails { get; set; }

        public DbSet<BudgetCategory> BudgetCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budget>(ConfigureBudget);
            modelBuilder.Entity<BudgetDetail>(ConfigureBudgetDetail);
            modelBuilder.Entity<BudgetCategory>(ConfigureBudgetCategory);
            modelBuilder.Entity<Transaction>(ConfigureTransaction);


        }

        private void ConfigureBudget(EntityTypeBuilder<Budget> builder)
        {
            builder.ToTable("Budget");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .UseIdentityColumn()
                .IsRequired();

        }

        private void ConfigureBudgetDetail(EntityTypeBuilder<BudgetDetail> builder)
        {
            builder.ToTable("BudgetDetail");

            builder.HasKey(bi => bi.Id);

            builder.Property(bi => bi.Amount)
                .HasColumnType("decimal(19,4)");

            builder.Property(bi => bi.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.HasOne(b => b.Budget)
                .WithMany(bi => bi.BudgetDetails);
        }

        private void ConfigureBudgetCategory(EntityTypeBuilder<BudgetCategory> builder)
        {
            builder.ToTable("BudgetCategory");

            builder.HasKey(bc => bc.Id);

            builder.Property(bc => bc.Id)
                .UseIdentityColumn()
                .IsRequired();

        }

        private void ConfigureTransaction(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Amount)
                .HasColumnType("decimal(19,4)");

            builder.Property(t => t.Id)
                .UseIdentityColumn()
                .IsRequired();

        }
    }
}
