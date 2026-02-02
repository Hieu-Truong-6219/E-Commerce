namespace ProductCatalogMicroService.Application;

public interface ICompanyService
{
    public Task<CompanyDto> CreateCompanyAsync(CompanyDto info);
    public Task<List<CompanyDto>> GetAllCompaniesAsync();
    public Task<CompanyDto?> GetCompanyDtoAsync(int id);
    public Task<CompanyDto?> UpdateCompanyAsync(int id, CompanyDto info);
    public Task<CompanyDto?> DeleteCompanyAsync(int id);
}
