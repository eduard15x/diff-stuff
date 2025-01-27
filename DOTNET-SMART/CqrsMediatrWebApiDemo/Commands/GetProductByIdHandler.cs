using MediatR;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly FakeData _fakeData;

    public GetProductByIdHandler(FakeData fakeData) => _fakeData = fakeData;

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _fakeData.GetProductById(request.id);
    }
}
