using InventoryManager.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired(false);
            modelBuilder.Entity<Product>().Property(p => p.ImageUrl).IsRequired(false);
            var productCategories = new List<ProductCategory>
{
                new ProductCategory { ProductCategoryId = "C001", CategoryName = "Fruit", Description = "Fresh fruits" },
                new ProductCategory { ProductCategoryId = "C002", CategoryName = "Vegetables", Description = "Fresh vegetables" },
                new ProductCategory { ProductCategoryId = "C003", CategoryName = "Dairy", Description = "Dairy products" },
                new ProductCategory { ProductCategoryId = "C004", CategoryName = "Beverages", Description = "Drinks and beverages" },
                new ProductCategory { ProductCategoryId = "C005", CategoryName = "Snacks", Description = "Packaged snacks" }
            };

            var products = new List<Product>{
                new Product { ProductId = "P001", ProductName = "Apple", ProductPrice = 2.5, ProductCategoryId = "C001", SupplierId = "S001",ImageUrl = "Images\\Apple.jfif" },
                new Product { ProductId = "P002", ProductName = "Banana", ProductPrice = 1.8, ProductCategoryId = "C001", SupplierId = "S002" },
                new Product { ProductId = "P003", ProductName = "Carrot", ProductPrice = 0.5, ProductCategoryId = "C002", SupplierId = "S003" },
                new Product { ProductId = "P004", ProductName = "Broccoli", ProductPrice = 1.2, ProductCategoryId = "C002", SupplierId = "S004" },
                new Product { ProductId = "P005", ProductName = "Milk", ProductPrice = 1.0, ProductCategoryId = "C003", SupplierId = "S005" },
                new Product { ProductId = "P006", ProductName = "Cheese", ProductPrice = 3.0, ProductCategoryId = "C003", SupplierId = "S006",ImageUrl = "Images\\Cheese1.jfif" },
                new Product { ProductId = "P007", ProductName = "Soda", ProductPrice = 1.5, ProductCategoryId = "C004", SupplierId = "S007" },
                new Product { ProductId = "P008", ProductName = "Orange Juice", ProductPrice = 2.0, ProductCategoryId = "C004", SupplierId = "S008" },
                new Product { ProductId = "P009", ProductName = "Chips", ProductPrice = 1.0, ProductCategoryId = "C005", SupplierId = "S009" },
                new Product { ProductId = "P010", ProductName = "Chocolate", ProductPrice = 1.8, ProductCategoryId = "C005", SupplierId = "S010" }
            };
            var suppliers = new List<Supplier>{
                new Supplier { SupplierId = "S001", SupplierName = "Rajesh Yadav", SupplierContact = "1234567890", SupplierAddress = "Pimpri-Chinchwad" },
                new Supplier { SupplierId = "S002", SupplierName = "Suresh Gupta", SupplierContact = "9876543210", SupplierAddress = "Baner, Pune" },
                new Supplier { SupplierId = "S003", SupplierName = "Meera Sharma", SupplierContact = "9123456789", SupplierAddress = "Hinjewadi, Pune" },
                new Supplier { SupplierId = "S004", SupplierName = "Anil Kumar", SupplierContact = "9988776655", SupplierAddress = "Kothrud, Pune" },
                new Supplier { SupplierId = "S005", SupplierName = "Sunita Verma", SupplierContact = "9876123450", SupplierAddress = "Viman Nagar, Pune" },
                new Supplier { SupplierId = "S006", SupplierName = "Prakash Patel", SupplierContact = "9765432198", SupplierAddress = "Wakad, Pune" },
                new Supplier { SupplierId = "S007", SupplierName = "Arjun Desai", SupplierContact = "8888999944", SupplierAddress = "Aundh, Pune" },
                new Supplier { SupplierId = "S008", SupplierName = "Kavita Joshi", SupplierContact = "9988001122", SupplierAddress = "Hadapsar, Pune" }
            };
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<ProductCategory>().HasData(productCategories);
            modelBuilder.Entity<Supplier>().HasData(suppliers);
        }
    }
}
