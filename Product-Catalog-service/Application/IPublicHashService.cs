using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Application;

public interface IPublicHashService
{
    public string HashPublicHash(Product product);
}
