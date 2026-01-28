using ProductCatalogMicroService.Application;

namespace ProductCatalogMicroService.Infrastructure;

public class ProductService(IProductRepository productRepository, ICompanyService companyService)
    : IProductService
{
    private readonly IProductRepository _repo = productRepository;
    private readonly ICompanyService _companyService = companyService;

    public async Task<ProductDto> CreateProductAsync(int companyId, ProductDto info)
    {
        // Throwing error since validating company access should have been done before hand
        var companyDto =
            _companyService.GetCompanyDto(companyId)
            ?? throw new Exception("Invalid company provided");
        var company = companyDto.ToCompany(companyId);
        var product = info.ToProduct(company);

        var createdProduct = await _repo.CreateProductAsync(product);
        return createdProduct.ToDto();
    }

    public List<ProductDto> GetAllProducts()
    {
        var products = _repo.GetAllProducts();

        return products.Select(product => product.ToDto()).ToList();
    }

    public List<CompanyProductsDto> GetAllCompanyProducts(int companyId)
    {
        throw new NotImplementedException();
    }

    public ProductDto? GetProductDto(int id)
    {
        var product = _repo.GetProduct(id);

        return (product == null) ? null : product.ToDto();
    }

    public async Task<ProductDto?> UpdateProductAsync(int companyId, int productId, ProductDto info)
    {
        var companyDto =
            _companyService.GetCompanyDto(companyId)
            ?? throw new Exception("Invalid company provided");
        var company = companyDto.ToCompany(companyId);
        var product = info.ToProduct(company);

        var updatedProduct = await _repo.CreateProductAsync(product);
        return (updatedProduct == null) ? null : updatedProduct.ToDto();
    }

    public async Task<ProductDto?> DeleteProductAsync(int productId)
    {
        var deletedProduct = await _repo.DeleteProductAsync(productId);
        return (deletedProduct == null) ? null : deletedProduct.ToDto();
    }
}
