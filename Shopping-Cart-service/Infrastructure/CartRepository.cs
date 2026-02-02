using ShoppingCartMicroService.Application;
using ShoppingCartMicroService.Domain;

namespace ShoppingCartMicroService.Infrastructure;

public class CartRepository(CartDbContext context) : ICartRepository
{
    private readonly CartDbContext _context = context;

    public async Task<Cart> CreateCartAsync(Cart info)
    {
        var result = _context.Carts.Add(info);

        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public List<Cart> GetAllCarts()
    {
        return _context.Carts.ToList();
    }

    public Cart? GetCart(int id)
    {
        return _context.Carts.Find(id);
    }

    public async Task<Cart?> UpdateCartAsync(Cart info)
    {
        var product = await _context.Carts.FindAsync(info.Id);

        if (product == null)
            return null;

        product.Name = info.Name;
        product.Description = info.Description;

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Cart?> DeleteCartAsync(int id)
    {
        var product = _context.Carts.SingleOrDefault(product => product.Id == id);

        if (product == null)
            return null;

        _context.Remove(product);

        await _context.SaveChangesAsync();

        return product;
    }
}
