using p.SessionsDemo.Models;
namespace p.SessionsDemo.Services
{
    public class ProductService
    {
        // In-memory product list stored here
        private static List<Product> _products = new()
        {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Description = "High performance laptop with 16GB RAM and 512GB SSD.",
                    Price = 90000,
                    Category = "Electronics",
                    StockQuantity = 15,
                    ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=600&q=80",
                    CreatedDate = DateTime.Now.AddDays(-35),
                    IsActive = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Smartphone",
                    Description = "Latest model smartphone with OLED display and great camera.",
                    Price = 35000,
                    Category = "Electronics",
                    StockQuantity = 40,
                    ImageUrl = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?auto=format&fit=crop&w=600&q=80",
                    CreatedDate = DateTime.Now.AddDays(-18),
                    IsActive = true
                },
                new Product
                {
                    Id = 3,
                    Name = "Headphones",
                    Description = "Noise-cancelling over-ear headphones with Bluetooth connectivity.",
                    Price = 7000,
                    Category = "Accessories",
                    StockQuantity = 0,
                    ImageUrl = "https://images.unsplash.com/photo-1511367461989-f85a21fda167?auto=format&fit=crop&w=600&q=80",
                    CreatedDate = DateTime.Now.AddDays(-25),
                    IsActive = true
                },
                new Product
                {
                    Id = 4,
                    Name = "Wireless Mouse",
                    Description = "Ergonomic wireless mouse with adjustable DPI and silent clicks.",
                    Price = 1500,
                    Category = "Accessories",
                    StockQuantity = 25,
                    ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=600&q=80",
                    CreatedDate = DateTime.Now.AddDays(-10),
                    IsActive = true
                }
        };

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}