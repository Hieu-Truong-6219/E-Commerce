using ProductCatalogMicroService.Application;
using ProductCatalogMicroService.Domain; // Using for testing. Delete.

namespace ProductCatalogMicroService.Infrastructure;

public class ProductService(IProductRepository productRepository, ICompanyService companyService)
    : IProductService
{
    private readonly IProductRepository _repo = productRepository;
    private readonly ICompanyService _companyService = companyService;

    public async Task<ProductDto> CreateProductAsync(int companyId, ProductDto info)
    {
        // Need to redo this. Calling GetCompanyDto maybe even referencing the company service causes an error.
        // Throwing error since validating company access should have been done before hand
        var companyDto =
            _companyService.GetCompanyDto(companyId)
            ?? throw new Exception("Invalid company provided");

        var company = companyDto.ToCompany(companyId);
        var product = info.ToProduct(company);

        var createdProduct = await _repo.CreateProductAsync(
            new Product()
            {
                Company = new Company() { Name = "testing" },
                PublicHash = "",
                Name = "testing",
                Cost = 10,
                Description = "please for the love of god work",
            }
        );

        return createdProduct.ToDto();
    }

    public List<ProductDto> GetAllProducts()
    {
        var products = _repo.GetAllProducts();

        return products.Select(product => product.ToDto()).ToList();
    }

    public CompanyProductsDto GetAllCompanyProducts(int companyId)
    {
        var companyDto =
            _companyService.GetCompanyDto(companyId)
            ?? throw new Exception("Invalid company provided");

        var products = _repo.GetAllProducts().Where(product => product.Company.Id == companyId);

        return new CompanyProductsDto()
        {
            Company = companyDto,
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
