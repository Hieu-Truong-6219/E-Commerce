using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Application;

public interface ICompanyValidationService
{
    public Task<bool> ValidateCompanyAsync(int id);
}
