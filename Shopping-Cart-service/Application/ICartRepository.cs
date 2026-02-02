using ShoppingCartMicroService.Domain;

namespace ShoppingCartMicroService.Application;

public interface ICartRepository
{
    public Task<Cart> CreateCartAsync(Cart info);
    public List<Cart> GetAllCarts();
    public Cart? GetCart(int id);
    public Task<Cart?> UpdateCartAsync(Cart info);
    public Task<Cart?> DeleteCartAsync(int id);
}
