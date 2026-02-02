using ProductCatalogMicroService.Application;

namespace ProductCatalogMicroService.Infrastructure;

public class CompanyValidationService(ICompanyService companyService) : ICompanyValidationService
{
    private readonly ICompanyService _companyService = companyService;

    public async Task<bool> ValidateCompanyAsync(int id)
    {
        return (await _companyService.GetCompanyDtoAsync(id) != null);
    }
}
