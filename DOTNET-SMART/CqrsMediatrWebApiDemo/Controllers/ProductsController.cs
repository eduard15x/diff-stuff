using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrWebApiDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    // private readonly IMediator _mediator; // this is composed by 2 interfaces (IMediator, IPublisher)
    private readonly IMediator _mediator;

    public ProductsController(
        ILogger<ProductsController> logger,
        // IMediator mediator,
        IMediator sender
    )
    {
        _logger = logger;
        // _mediator = mediator;
        _mediator = sender;
    }

    [HttpGet(Name = "GetProducts")]
    public async Task<ActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetProductsQuery());

        return Ok(products);

    }


    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<ActionResult> GetProductById(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        return Ok(product);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddProduct([FromBody] Product newProduct)
    {
        var newProductCreated = new Product()
        {
            Id = newProduct.Id,
            Name = newProduct.Name,
        };

        var result = await _mediator.Send(new CreateProductCommand(newProductCreated));
        return Ok(result);
    }


    [HttpPost("update")]
    public async Task<IActionResult> UpdateProduct([FromBody] Product newProduct)
    {
        var result = await _mediator.Send(new UpdateProductCommand(newProduct.Id, newProduct.Name));
        return Ok(result);
    }
}
