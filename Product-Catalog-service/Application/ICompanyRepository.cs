using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Application;

public interface ICompanyRepository
{
    public Task<Company> CreateCompanyAsync(Company info);
    public List<Company> GetAllCompanies();
    public Company? GetCompany(int id);
    public Task<Company?> UpdateCompanyAsync(Company info);
    public Task<Company?> DeleteCompanyAsync(int id);
}
