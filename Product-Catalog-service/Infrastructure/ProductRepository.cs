using ProductCatalogMicroService.Application;
using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Infrastructure;

public class ProductRepository(ProductDbContext context) : IProductRepository
{
    private readonly ProductDbContext _context = context;

    public async Task<Product> CreateProductAsync(Company company, Product info)
    {
        // company.Products.Add(info);
        info.Company = company;
        var result = await _context.Products.AddAsync(info);
        // var result = _context.Products.Add(info);

        await _context.SaveChangesAsync();

        // return info;
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

    public async Task<Product> UpdateProductAsync(Product info)
    {
        // Throwing error since product should have been checked before hand.
        var product =
            await _context.Products.FindAsync(info.Id)
            ?? throw new Exception("Invalid product provided");

        product.Company = info.Company;
        product.Name = info.Name;
        product.Cost = info.Cost;
        product.Description = info.Description;

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product> DeleteProductAsync(int id)
    {
        var product =
            await _context.Products.FindAsync(id)
            ?? throw new Exception("Invalid product provided");

        _context.Remove(product);

        await _context.SaveChangesAsync();

        return product;
    }
}
