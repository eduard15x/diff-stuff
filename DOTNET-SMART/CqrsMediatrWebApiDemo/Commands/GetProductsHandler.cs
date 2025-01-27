using MediatR;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly FakeData _fakeData;

    public GetProductsHandler(FakeData fakeData) => _fakeData = fakeData;

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _fakeData.GetProducts();
    }
}
