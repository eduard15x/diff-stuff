using MediatR;

public class CreateProductCommand : IRequest<Product>
{
    public Product ProductRequest { get; }
    public CreateProductCommand(Product productRequest)
    {
        this.ProductRequest = productRequest;
    }
}