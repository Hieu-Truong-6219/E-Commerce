namespace ProductCatalogMicroService.Application;

public interface IProductService
{
    public Task<ProductDto> CreateProductAsync(ProductDto info);
    public List<ProductDto> GetAllProducts();
    public ProductDto? GetProductDto(int id);
    public Task<ProductDto?> UpdateProductAsync(int id, ProductDto info);
    public Task<ProductDto?> DeleteProductAsync(int id);
}
