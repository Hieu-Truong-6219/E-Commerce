using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogMicroService.Application;
using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Presentation;

[ApiController]
[Route("[controller]")]
public class ProductController(
    IProductService productService,
    ICompanyValidationService companyValidationService
) : ControllerBase
{
    private readonly IProductService _productService = productService;
    private readonly ICompanyValidationService _companyValidationService = companyValidationService;

    [HttpPost("{companyId}")]
    public async Task<ActionResult<ProductDto>> CreateProductAsync(int companyId, ProductDto info)
    {
        if (await _companyValidationService.ValidateCompanyAsync(companyId) == false)
            return NotFound("Company not found");

        return Ok(await _productService.CreateProductAsync(companyId, info));
    }

    [HttpGet]
    public ActionResult<List<CompanyProductsDto>> GetAllProducts()
    {
        return Ok(_productService.GetAllProducts());
    }

    [HttpGet("{companyId}")]
    public async Task<ActionResult<CompanyProductsDto>> GetAllCompanyProducts(int companyId)
    {
        if (await _companyValidationService.ValidateCompanyAsync(companyId) == false)
            return NotFound("Company not found");

        return Ok(await _productService.GetAllCompanyProductsAsync(companyId));
    }

    [HttpGet("{companyId}/{productId}")]
    public async Task<ActionResult<ProductDto>?> GetProductDto(int companyId, int productId)
    {
        if (await _companyValidationService.ValidateCompanyAsync(companyId) == false)
            return NotFound("Company not found");

        var product = _productService.GetProductDto(productId);
        return (product != null) ? Ok(product) : NotFound("Product not found");
    }

    [HttpPut("{companyId}/{productId}")]
    public async Task<ActionResult<ProductDto>?> UpdateProductAsync(
        int companyId,
        int productId,
        ProductDto info
    )
    {
        if (await _companyValidationService.ValidateCompanyAsync(companyId) == false)
            return NotFound("Company not found");

        var product = await _productService.UpdateProductAsync(companyId, productId, info);
        return (product != null) ? Ok(product) : NotFound("Product not found");
    }

    [HttpDelete("{productId}")]
    public async Task<ActionResult<ProductDto>?> DeleteProductAsync(int productId)
    {
        var product = await _productService.DeleteProductAsync(productId);
        return (product != null) ? Ok(product) : NotFound("Product not found");
    }
}
