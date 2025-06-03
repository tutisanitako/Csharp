using FinalProject.EF;
using System.Data.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext() : base("name=DefaultConnection")
    {
        // Enable automatic migrations for Code First
        Database.SetInitializer(new CreateDatabaseIfNotExists<AppDbContext>());
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Salary> Salaries { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Employee-Position relationship
        modelBuilder.Entity<Employee>()
            .HasRequired(e => e.Position)
            .WithMany()
            .HasForeignKey(e => e.PositionId)
            .WillCascadeOnDelete(false);

        // Salary-Employee relationship
        modelBuilder.Entity<Salary>()
            .HasRequired(s => s.Employee)
            .WithMany()
            .HasForeignKey(s => s.EmployeeId)
            .WillCascadeOnDelete(false);

        // Configure decimal precision
        modelBuilder.Entity<Employee>()
            .Property(e => e.BaseSalary)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Position>()
            .Property(p => p.BonusPercent)
            .HasPrecision(5, 2);

        modelBuilder.Entity<Salary>()
            .Property(s => s.TotalSalary)
            .HasPrecision(18, 2);

        base.OnModelCreating(modelBuilder);
    }
}