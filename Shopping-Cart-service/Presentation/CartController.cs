using ShoppingCartMicroService.Application;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartMicroService.Presentation;

[ApiController]
[Route("[controller]")]
public class CartController(ICartService productService) : ControllerBase
{
    private readonly ICartService _productService = productService;

    [HttpPost]
    public async Task<ActionResult<CartDto>> CreateCartAsync(CartDto info)
    {
        return Ok(await _productService.CreateCartAsync(info));
    }

    [HttpGet]
    public ActionResult<List<CartDto>> GetAllCarts()
    {
        return Ok(_productService.GetAllCarts());
    }

    [HttpGet("{id}")]
    public ActionResult<CartDto>? GetCartDto(int id)
    {
        return Ok(_productService.GetCartDto(id));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CartDto>?> UpdateCartAsync(int id, CartDto info)
    {
        return Ok(await _productService.UpdateCartAsync(id, info));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CartDto>?> DeleteCartAsync(int id)
    {
        return Ok(await _productService.DeleteCartAsync(id));
    }
}
