using ProductCatalogMicroService.Application;

namespace ProductCatalogMicroService.Infrastructure;

public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
{
    private readonly ICompanyRepository _repo = companyRepository;

    public async Task<CompanyDto> CreateCompanyAsync(CompanyDto company)
    {
        var product = await _repo.CreateCompanyAsync(company.ToCompany());
        return product.ToDto();
    }

    public List<CompanyDto> GetAllCompanies()
    {
        var products = _repo.GetAllCompanies();

        return products.Select(product => product.ToDto()).ToList();
    }

    public CompanyDto? GetCompanyDto(int id)
    {
        var product = _repo.GetCompany(id);

        return (product == null) ? null : product.ToDto();
    }

    public async Task<CompanyDto?> UpdateCompanyAsync(int id, CompanyDto info)
    {
        var product = await _repo.UpdateCompanyAsync(info.ToCompany(id));

        return (product == null) ? null : product.ToDto();
    }

    public async Task<CompanyDto?> DeleteCompanyAsync(int id)
    {
        var product = await _repo.DeleteCompanyAsync(id);

        return (product == null) ? null : product.ToDto();
    }
}
