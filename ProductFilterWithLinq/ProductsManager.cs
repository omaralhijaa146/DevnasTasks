namespace ProductFilterWithLinq;

public class ProductsManager
{
    private readonly IDeserializer<Product> _deserializer;
    
    private List<ProductFilteredByPriceDto> _filteredProducts;
    
    private readonly string _filePath;
    
    public ProductsManager(IDeserializer<Product> deserializer,string filePath)
    {
        _deserializer = deserializer;
        _filePath = filePath;
    }
    
    private List<Product> GetProducts()
    {
        if (string.IsNullOrEmpty(_filePath))
            throw new ArgumentException("Invalid file path");
        
        return _deserializer.Deserialize(_filePath);
    }

    public List<ProductFilteredByPriceDto> FilterProductsByPrice(int price=50)
    {
        var products = GetProducts();
        _filteredProducts= products.Where(x=>x.Price<50).OrderByDescending(x => x.Price).Select(x => new ProductFilteredByPriceDto
        {
            Name = x.Name,
            Price = x.Price
        }).ToList();
        
        return _filteredProducts.ToList();
    }

    public void PrintFilteredProducts()
    {
        _filteredProducts.ForEach(x => Console.WriteLine($"{x.Name} - {x.Price}"));
    }
}