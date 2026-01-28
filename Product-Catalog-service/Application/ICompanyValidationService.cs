using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Application;

public interface ICompanyValidationService
{
    public bool ValidateCompany(int id);
}
