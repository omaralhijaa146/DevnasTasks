namespace ProductFilterWithLinq;

class Program
{
    static void Main(string[] args)
    {
        string productsPath = "C:\\Users\\User\\RiderProjects\\DevnasTasks\\ProductFilterWithLinq\\products.json";
        var deserializer = new JsonDeserializer<Product>();
        var productsManager = new ProductsManager(deserializer,productsPath);
        productsManager.FilterProductsByPrice();
        productsManager.PrintFilteredProducts();
    }
}

/*
 * Product Filter with LINQ

Covered Topics: LINQ, Collections

Scenario: Load products from JSON and produce a sorted view for marketing. ([learn.microsoft.com][8])

Requirements:

Deserialize sample product data.

Filter items priced < $50, select {Name, Price}.

Order by price descending and display results.

 */