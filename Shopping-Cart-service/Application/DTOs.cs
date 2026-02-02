using ShoppingCartMicroService.Domain;

namespace ShoppingCartMicroService.Application;

public class CartDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
