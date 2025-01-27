using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrWebApiDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    // private readonly IMediator _mediator; // this is composed by 2 interfaces (ISender, IPublisher)
    private readonly ISender _sender;

    public ProductsController(
        ILogger<ProductsController> logger,
        // IMediator mediator,
        ISender sender
    )
    {
        _logger = logger;
        // _mediator = mediator;
        _sender = sender;
    }

    [HttpGet(Name = "GetProducts")]
    public async Task<ActionResult> GetProducts()
    {
        var products = await _sender.Send(new GetProductsQuery());

        return Ok(products);

    }


    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<ActionResult> GetProductById(int id)
    {
        var product = await _sender.Send(new GetProductByIdQuery(id));

        return Ok(product);
    }

}
