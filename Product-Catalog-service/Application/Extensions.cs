using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Application;

public static class ModelExtensions
{
    public static ProductDto ToDto(this Product info)
    {
        return new ProductDto { Name = info.Name, Description = info.Description };
    }

    public static Product To(this ProductDto dto, int id = default)
    {
        return new Product
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description,
        };
    }
}
