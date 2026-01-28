using ProductCatalogMicroService.Application;
using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Infrastructure;

public class CompanyRepository(ProductDbContext context) : ICompanyRepository
{
    private readonly ProductDbContext _context = context;

    public async Task<Company> CreateCompanyAsync(Company info)
    {
        var result = _context.Companies.Add(info);

        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public List<Company> GetAllCompanies()
    {
        return _context.Companies.ToList();
    }

    public Company? GetCompany(int id)
    {
        return _context.Companies.Find(id);
    }

    public async Task<Company?> UpdateCompanyAsync(Company info)
    {
        var product = await _context.Companies.FindAsync(info.Id);

        if (product == null)
            return null;

        product.Name = info.Name;
        product.Products = info.Products;

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Company?> DeleteCompanyAsync(int id)
    {
        var product = _context.Companies.SingleOrDefault(product => product.Id == id);

        if (product == null)
            return null;

        _context.Remove(product);

        await _context.SaveChangesAsync();

        return product;
    }
}
