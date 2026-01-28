using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Application;

public class ProductDto
{
    public string PublicHash { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public float Cost { get; set; }
    public string Description { get; set; } = string.Empty;
}

public class ProductInfoDto
{
    public int Id { get; set; }
    public Company Company { get; set; } = null;
    public string PublicHash { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public float Cost { get; set; }
    public string Description { get; set; } = string.Empty;
}

public class CompanyDto
{
    public string Name { get; set; } = string.Empty;
}

public class CompanyProductsDto
{
    public CompanyDto Company { get; set; } = new CompanyDto();
    public ICollection<ProductDto> Products { get; set; } = [];
}
