namespace QuizNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        City = c.String(maxLength: 40),
                        Country = c.String(maxLength: 40),
                        Phone = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.FirstName, t.LastName }, name: "IndexCustomerName");
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderNumber = c.String(maxLength: 10),
                        CustomerId = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.OrderDate, name: "IndexOrderOrderDate")
                .Index(t => t.CustomerId, name: "IndexOrderCustomerId");
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId, name: "IndexOrderItemOrderId")
                .Index(t => t.ProductId, name: "IndexOrderItemProductId");
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        SupplierId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Package = c.String(maxLength: 30),
                        IsDiscontinued = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.ProductName, name: "IndexProductName")
                .Index(t => t.SupplierId, name: "IndexProductSupplierId");
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 40),
                        ContactName = c.String(maxLength: 50),
                        ContactTitle = c.String(maxLength: 40),
                        City = c.String(maxLength: 40),
                        Country = c.String(maxLength: 40),
                        Phone = c.String(maxLength: 30),
                        Fax = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CompanyName, name: "IndexSupplierName")
                .Index(t => t.Country, name: "IndexSupplierCountry");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Suppliers", "IndexSupplierCountry");
            DropIndex("dbo.Suppliers", "IndexSupplierName");
            DropIndex("dbo.Products", "IndexProductSupplierId");
            DropIndex("dbo.Products", "IndexProductName");
            DropIndex("dbo.OrderItems", "IndexOrderItemProductId");
            DropIndex("dbo.OrderItems", "IndexOrderItemOrderId");
            DropIndex("dbo.Orders", "IndexOrderCustomerId");
            DropIndex("dbo.Orders", "IndexOrderOrderDate");
            DropIndex("dbo.Customers", "IndexCustomerName");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
