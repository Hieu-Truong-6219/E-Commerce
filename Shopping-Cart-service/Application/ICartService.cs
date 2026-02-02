namespace ShoppingCartMicroService.Application;

public interface ICartService
{
    public Task<CartDto> CreateCartAsync(CartDto info);
    public List<CartDto> GetAllCarts();
    public CartDto? GetCartDto(int id);
    public Task<CartDto?> UpdateCartAsync(int id, CartDto info);
    public Task<CartDto?> DeleteCartAsync(int id);
}
