using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Application;

public interface ICompanyRepository
{
    public Task<Company> CreateCompanyAsync(Company info);
    public Task<List<Company>> GetAllCompaniesAsync();
    public Task<Company?> GetCompanyAsync(int id);
    public Task<Company?> UpdateCompanyAsync(Company info);
    public Task<Company?> DeleteCompanyAsync(int id);
}
