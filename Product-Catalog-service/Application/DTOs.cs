using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Application;

public class ProductDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
