using MediatR;

public record GetProductByIdQuery(int id) : IRequest<Product>;

// public class GetProductByIdQuery : IRequest<Product>
// {
//     public int Id { get; }

//     public GetProductByIdQuery(int Id)
//     {
//         this.Id = Id;
//     }
// }