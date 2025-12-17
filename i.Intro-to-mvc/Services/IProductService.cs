using i.Intro_to_mvc.Models;

namespace i.Intro_to_mvc.Services;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    Product? GetProductById(int id);
}