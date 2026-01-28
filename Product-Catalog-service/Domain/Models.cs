namespace ProductCatalogMicroService.Domain;

public class Product
{
    public int Id { get; set; }
    public Company Company { get; set; } = new Company();
    public string PublicHash { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public float Cost { get; set; }
    public string Description { get; set; } = string.Empty;
}

// Should probably spin this off as a microservice, but hey, just making an MVP
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Product> Products = [];
}
