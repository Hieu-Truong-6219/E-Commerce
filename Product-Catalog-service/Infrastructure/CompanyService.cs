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

    public async Task<List<CompanyDto>> GetAllCompaniesAsync()
    {
        var companies = await _repo.GetAllCompaniesAsync();

        return companies.Select(company => company.ToDto()).ToList();
    }

    public async Task<CompanyDto?> GetCompanyDtoAsync(int id)
    {
        var company = await _repo.GetCompanyAsync(id);

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
