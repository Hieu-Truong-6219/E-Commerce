using ProductCatalogMicroService.Application;
using ProductCatalogMicroService.Domain; // Using for testing. Delete.

namespace ProductCatalogMicroService.Infrastructure;

public class ProductService(
    IProductRepository productRepository,
    ICompanyRepository companyRepository
) : IProductService
{
    private readonly IProductRepository _repo = productRepository;
    private readonly ICompanyRepository _companyRepository = companyRepository;

    public async Task<ProductDto> CreateProductAsync(int companyId, ProductDto info)
    {
        // Throwing error since validating company access should have been done before hand
        var company =
            await _companyRepository.GetCompanyAsync(companyId)
            ?? throw new Exception("Invalid company Id given");
        var product = info.ToProduct(company);

        var createdProduct = await _repo.CreateProductAsync(company, product);

        return createdProduct.ToDto();
    }

    public List<ProductDto> GetAllProducts()
    {
        var products = _repo.GetAllProducts();

        return products.Select(product => product.ToDto()).ToList();
    }

    public async Task<CompanyProductsDto> GetAllCompanyProductsAsync(int companyId)
    {
        var company =
            await _companyRepository.GetCompanyAsync(companyId)
            ?? throw new Exception("Invalid company Id given");
        var products = _repo.GetAllProducts().Where(product => product.Company.Id == companyId);

        return new CompanyProductsDto()
        {
            Company = company.ToDto(),
            Products = products.Select(product => product.ToDto()).ToList(),
        };
    }

    public ProductDto? GetProductDto(int id)
    {
        var product = _repo.GetProduct(id);

        return (product == null) ? null : product.ToDto();
    }

    public async Task<ProductDto?> UpdateProductAsync(int companyId, int productId, ProductDto info)
    {
        var company =
            await _companyRepository.GetCompanyAsync(companyId)
            ?? throw new Exception("Invalid company Id given");
        var product = info.ToProduct(company);

        var updatedProduct = await _repo.UpdateProductAsync(product);
        return (updatedProduct == null) ? null : updatedProduct.ToDto();
    }

    public async Task<ProductDto?> DeleteProductAsync(int productId)
    {
        var deletedProduct = await _repo.DeleteProductAsync(productId);
        return (deletedProduct == null) ? null : deletedProduct.ToDto();
    }
}
