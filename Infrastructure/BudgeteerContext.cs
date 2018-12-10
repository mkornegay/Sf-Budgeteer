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

        public DbSet<BudgetItem> BudgetItems { get; set; }

        public DbSet<BudgetCategory> BudgetCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budget>(ConfigureBudget);
            modelBuilder.Entity<BudgetItem>(ConfigureBudgetItem);
            modelBuilder.Entity<BudgetCategory>(ConfigureBudgetCategory);

        }

        private void ConfigureBudget(EntityTypeBuilder<Budget> builder)
        {
            builder.ToTable("Budget");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .UseSqlServerIdentityColumn()
                .IsRequired();

        }

        private void ConfigureBudgetItem(EntityTypeBuilder<BudgetItem> builder)
        {
            builder.ToTable("BudgetItem");

            builder.HasKey(bi => bi.Id);

            builder.Property(bi => bi.Amount)
                .HasColumnType("decimal(19,4)");

            builder.Property(bi => bi.Id)
                .UseSqlServerIdentityColumn()
                .IsRequired();

            builder.HasOne(b => b.Budget)
                .WithMany(bi => bi.BudgetItems);
        }

        private void ConfigureBudgetCategory(EntityTypeBuilder<BudgetCategory> builder)
        {
            builder.ToTable("BudgetCategory");

            builder.HasKey(bc => bc.Id);

            builder.Property(bc => bc.Id)
                .UseSqlServerIdentityColumn()
                .IsRequired();

        }
    }
}
