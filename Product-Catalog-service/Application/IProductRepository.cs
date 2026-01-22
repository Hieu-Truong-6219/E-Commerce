using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Application;

public interface IProductRepository
{
    public Task<Product> CreateProductAsync(Product info);
    public List<Product> GetAllProducts();
    public Product? GetProduct(int id);
    public Task<Product?> UpdateProductAsync(Product info);
    public Task<Product?> DeleteProductAsync(int id);
}
