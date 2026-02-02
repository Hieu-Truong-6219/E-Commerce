using ShoppingCartMicroService.Application;

namespace ShoppingCartMicroService.Infrastructure;

public class CartService(ICartRepository productRepository) : ICartService
{
    private readonly ICartRepository _repo = productRepository;

    public async Task<CartDto> CreateCartAsync(CartDto info)
    {
        var product = await _repo.CreateCartAsync(info.To());
        return product.ToDto();
    }

    public List<CartDto> GetAllCarts()
    {
        var products = _repo.GetAllCarts();

        return products.Select(product => product.ToDto()).ToList();
    }

    public CartDto? GetCartDto(int id)
    {
        var product = _repo.GetCart(id);

        return (product == null) ? null : product.ToDto();
    }

    public async Task<CartDto?> UpdateCartAsync(int id, CartDto info)
    {
        var product = await _repo.UpdateCartAsync(info.To(id));

        return (product == null) ? null : product.ToDto();
    }

    public async Task<CartDto?> DeleteCartAsync(int id)
    {
        var product = await _repo.DeleteCartAsync(id);

        return (product == null) ? null : product.ToDto();
    }
}
