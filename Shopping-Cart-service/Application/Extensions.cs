using ShoppingCartMicroService.Domain;

namespace ShoppingCartMicroService.Application;

public static class ModelExtensions
{
    public static CartDto ToDto(this Cart info)
    {
        return new CartDto { Name = info.Name, Description = info.Description };
    }

    public static Cart To(this CartDto dto, int id = default)
    {
        return new Cart
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description,
        };
    }
}
