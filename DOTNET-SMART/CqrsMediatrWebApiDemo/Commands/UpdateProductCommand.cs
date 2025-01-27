using MediatR;

public class UpdateProductCommand : IRequest<bool>
{
    public int ProdId { get; }
    public string ProductName { get; }
    public UpdateProductCommand(int prodId, string productName)
    {
        this.ProdId = prodId;
        this.ProductName = productName;
    }
}