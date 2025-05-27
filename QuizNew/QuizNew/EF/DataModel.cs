using QuizNew.EF;
using System.Data.Entity;

public class DataModel : DbContext
{
    public DataModel() : base("name=DataModel")
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .HasIndex(e => new { e.FirstName, e.LastName })
            .HasName("IndexCustomerName");

        modelBuilder.Entity<Supplier>()
            .HasIndex(e => e.CompanyName)
            .HasName("IndexSupplierName");

        modelBuilder.Entity<Supplier>()
            .HasIndex(e => e.Country)
            .HasName("IndexSupplierCountry");

        modelBuilder.Entity<Product>()
            .HasIndex(e => e.SupplierId)
            .HasName("IndexProductSupplierId");

        modelBuilder.Entity<Product>()
            .HasIndex(e => e.ProductName)
            .HasName("IndexProductName");

        modelBuilder.Entity<Order>()
            .HasIndex(e => e.CustomerId)
            .HasName("IndexOrderCustomerId");

        modelBuilder.Entity<Order>()
            .HasIndex(e => e.OrderDate)
            .HasName("IndexOrderOrderDate");

        modelBuilder.Entity<OrderItem>()
            .HasIndex(e => e.OrderId)
            .HasName("IndexOrderItemOrderId");

        modelBuilder.Entity<OrderItem>()
            .HasIndex(e => e.ProductId)
            .HasName("IndexOrderItemProductId");

        modelBuilder.Entity<Order>()
            .HasRequired(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .WillCascadeOnDelete(true);

        modelBuilder.Entity<Product>()
            .HasRequired(p => p.Supplier)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.SupplierId)
            .WillCascadeOnDelete(true);

        modelBuilder.Entity<OrderItem>()
            .HasRequired(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .WillCascadeOnDelete(true);

        modelBuilder.Entity<OrderItem>()
            .HasRequired(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId)
            .WillCascadeOnDelete(false);
    }
}