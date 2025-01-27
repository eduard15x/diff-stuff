public class FakeData
{
    private static List<Product> _products;

    public FakeData()
    {
        _products = new List<Product>()
        {
            new Product() { Id = 1, Name = "Prod1"},
            new Product() { Id = 2, Name = "Prod2"},
            new Product() { Id = 3, Name = "Prod3"}
        };
    }

    public async Task AddProduct(Product product)
    {
        _products.Add(product);

        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Product>> GetProducts() => await Task.FromResult(_products);

    public async Task<Product> GetProductById(int id) => await Task.FromResult(_products.SIngle(p => p.Id == id));
}