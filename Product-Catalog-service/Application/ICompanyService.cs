namespace ProductCatalogMicroService.Application;

public interface ICompanyService
{
    public Task<CompanyDto> CreateCompanyAsync(CompanyDto info);
    public List<CompanyDto> GetAllCompanies();
    public CompanyDto? GetCompanyDto(int id);
    public Task<CompanyDto?> UpdateCompanyAsync(int id, CompanyDto info);
    public Task<CompanyDto?> DeleteCompanyAsync(int id);
}
