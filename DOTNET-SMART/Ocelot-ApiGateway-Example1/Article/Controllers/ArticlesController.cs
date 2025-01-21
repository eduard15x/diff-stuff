using Microsoft.AspNetCore.Mvc;

namespace Article.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticlesController : ControllerBase
{
    private readonly ILogger<ArticlesController> _logger;

    public ArticlesController(ILogger<ArticlesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetArticles")]
    public async Task<IActionResult> GetArticles()
    {
        await Task.CompletedTask;
        return Ok("get articles");
    }

    [HttpGet("{id}", Name = "GetSingleArticle")]
    public async Task<IActionResult> GetSingleArticle([FromRoute] int id)
    {
        await Task.CompletedTask;
        return Ok($"get article with id {id}");
    }

    [HttpPost("{id}", Name = "PostSingleArticle")]
    public async Task<IActionResult> PostSingleArticle([FromRoute] int id)
    {
        await Task.CompletedTask;
        return Ok($"post article with id {id}");
    }
}
