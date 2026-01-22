using ProductCatalogMicroService.Application;

namespace ProductCatalogMicroService.Infrastructure;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _repo = productRepository;

    public async Task<ProductDto> CreateProductAsync(ProductDto info)
    {
        var product = await _repo.CreateProductAsync(info.To());
        return product.ToDto();
    }

    public List<ProductDto> GetAllProducts()
    {
        var products = _repo.GetAllProducts();

        return products.Select(product => product.ToDto()).ToList();
    }

    public ProductDto? GetProductDto(int id)
    {
        var product = _repo.GetProduct(id);

        return (product == null) ? null : product.ToDto();
    }

    public async Task<ProductDto?> UpdateProductAsync(int id, ProductDto info)
    {
        var product = await _repo.UpdateProductAsync(info.To(id));

        return (product == null) ? null : product.ToDto();
    }

    public async Task<ProductDto?> DeleteProductAsync(int id)
    {
        var product = await _repo.DeleteProductAsync(id);

        return (product == null) ? null : product.ToDto();
    }
}
