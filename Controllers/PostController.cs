using butterfly_dotnet_mvc.Context;
using butterfly_dotnet_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace butterfly_dotnet_mvc.Controllers;

[Route("api/post")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly DataContext _context;

    public PostController(DataContext context)
    {
        _context = context;
    }

    [Route("get")]
    [HttpGet]
    public async Task<ActionResult<Post>> GetPost([FromBody]int id)
    {
        var post = await _context.Posts.Where(u=> u.Id == id).FirstAsync();
        return post;
    }
}
