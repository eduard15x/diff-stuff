using MediatR;

public class CreateNewProductHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly FakeData _fakeData;

    public CreateNewProductHandler(FakeData fakeData) => _fakeData = fakeData;

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _fakeData.AddProduct(request.ProductRequest);
        return await Task.FromResult(request.ProductRequest);
    }
}
