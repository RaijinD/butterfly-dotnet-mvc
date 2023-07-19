using Microsoft.AspNetCore.Mvc;
using butterfly_dotnet_mvc.Context;
using butterfly_dotnet_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace butterfly_dotnet_mvc.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;

    }

    [Route("get")]
    [HttpGet]
    public async Task<ActionResult<User>> GetUserInfo(int id) {
        var user = await _context.Users.Where(u => u.Id == id).FirstAsync();
        return user;
    }

    [Route("create")]
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user) {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return await GetUserInfo(user.Id);
    }

    // [HttpGet]
    // public ActionResult<User> GetUserInfo2(int userId) {
    //     var user =  _context.Users.Where(u => u.Id == userId).First();
    //     return Ok(user);
    // }

}
