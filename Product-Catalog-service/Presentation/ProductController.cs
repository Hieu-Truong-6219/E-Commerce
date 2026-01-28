using Microsoft.AspNetCore.Mvc;
using ProductCatalogMicroService.Application;

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
        if (_companyValidationService.ValidateCompany(companyId))
            return NotFound("Company not found");

        return Ok(await _productService.CreateProductAsync(companyId, info));
    }

    [HttpGet]
    public ActionResult<List<CompanyProductsDto>> GetAllProducts()
    {
        return Ok(_productService.GetAllProducts());
    }

    [HttpGet("{companyId}")]
    public ActionResult<List<CompanyProductsDto>> GetAllCompanyProducts(int companyId)
    {
        if (_companyValidationService.ValidateCompany(companyId))
            return NotFound("Company not found");

        return Ok(_productService.GetAllCompanyProducts(companyId));
    }

    [HttpGet("{companyId}/{productId}")]
    public ActionResult<ProductDto>? GetProductDto(int companyId, int productId)
    {
        if (_companyValidationService.ValidateCompany(companyId))
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
        if (_companyValidationService.ValidateCompany(companyId))
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
