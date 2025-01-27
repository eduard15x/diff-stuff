using MediatR;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly FakeData _fakeData;

    public UpdateProductHandler(FakeData fakeData) => _fakeData = fakeData;

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        return await _fakeData.UpdateProduct(request.ProdId, request.ProductName);
    }
}
