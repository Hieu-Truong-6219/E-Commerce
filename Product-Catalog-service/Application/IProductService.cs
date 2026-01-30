namespace ProductCatalogMicroService.Application;

public interface IProductService
{
    public Task<ProductDto> CreateProductAsync(int companyId, ProductDto info);
    public List<ProductDto> GetAllProducts();
    public CompanyProductsDto GetAllCompanyProducts(int companyId);
    public ProductDto? GetProductDto(int productId);
    public Task<ProductDto?> UpdateProductAsync(int companyId, int productId, ProductDto info);
    public Task<ProductDto?> DeleteProductAsync(int productId);
}
