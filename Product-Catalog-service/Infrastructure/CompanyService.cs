using ProductCatalogMicroService.Application;

namespace ProductCatalogMicroService.Infrastructure;

public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
{
    private readonly ICompanyRepository _repo = companyRepository;

    public async Task<CompanyDto> CreateCompanyAsync(CompanyDto info)
    {
        var company = await _repo.CreateCompanyAsync(info.ToCompany());
        return company.ToDto();
    }

    public List<CompanyDto> GetAllCompanies()
    {
        var companies = _repo.GetAllCompanies();

        return companies.Select(company => company.ToDto()).ToList();
    }

    public CompanyDto? GetCompanyDto(int id)
    {
        var company = _repo.GetCompany(id);

        return (company == null) ? null : company.ToDto();
    }

    public async Task<CompanyDto?> UpdateCompanyAsync(int id, CompanyDto info)
    {
        var company = await _repo.UpdateCompanyAsync(info.ToCompany(id));

        return (company == null) ? null : company.ToDto();
    }

    public async Task<CompanyDto?> DeleteCompanyAsync(int id)
    {
        var company = await _repo.DeleteCompanyAsync(id);

        return (company == null) ? null : company.ToDto();
    }
}
