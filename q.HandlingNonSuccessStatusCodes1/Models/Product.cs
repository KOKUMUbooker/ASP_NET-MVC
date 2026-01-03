namespace q.HandlingNonSuccessStatusCodes1.Models
{
    // Represents a Product entity with properties for ID, Name, and Price.
    public class Product
    {
        public int Id { get; set; }      // Unique identifier for the product
        public string Name { get; set; } = ""; // Name of the product
        public decimal Price { get; set; } // Price of the product
    }
}