using ProductCatalogMicroService.Application;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalogMicroService.Presentation;

[ApiController]
[Route("[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProductAsync(ProductDto info)
    {
        return Ok(await _productService.CreateProductAsync(info));
    }

    [HttpGet]
    public ActionResult<List<ProductDto>> GetAllProducts()
    {
        return Ok(_productService.GetAllProducts());
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDto>? GetProductDto(int id)
    {
        return Ok(_productService.GetProductDto(id));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDto>?> UpdateProductAsync(int id, ProductDto info)
    {
        return Ok(await _productService.UpdateProductAsync(id, info));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductDto>?> DeleteProductAsync(int id)
    {
        return Ok(await _productService.DeleteProductAsync(id));
    }
}
