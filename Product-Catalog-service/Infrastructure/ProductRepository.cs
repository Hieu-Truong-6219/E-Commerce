using ProductCatalogMicroService.Application;
using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Infrastructure;

public class ProductRepository(ProductDbContext context) : IProductRepository
{
    private readonly ProductDbContext _context = context;

    public async Task<Product> CreateProductAsync(Product info)
    {
        var result = _context.Products.Add(info);

        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public List<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public Product? GetProduct(int id)
    {
        return _context.Products.Find(id);
    }

    public async Task<Product?> UpdateProductAsync(Product info)
    {
        var product = await _context.Products.FindAsync(info.Id);

        if (product == null)
            return null;

        product.Company = info.Company;
        product.Name = info.Name;
        product.Cost = info.Cost;
        product.Description = info.Description;

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product?> DeleteProductAsync(int id)
    {
        var product = _context.Products.SingleOrDefault(product => product.Id == id);

        if (product == null)
            return null;

        _context.Remove(product);

        await _context.SaveChangesAsync();

        return product;
    }
}
