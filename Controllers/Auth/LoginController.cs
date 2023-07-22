using System.Diagnostics;
using butterfly_dotnet_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace butterfly_dotnet_mvc;

public class LoginController : Controller 
{
    private readonly ILogger<LoginController> _logger = null!;

    public IActionResult Index()
    {
        return View("/Views/Login/Index.cshtml");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task<ActionResult> Login([FromBody]User userLogin)
    {
        Console.WriteLine("Login");
        Console.WriteLine(userLogin.Email);
        Console.WriteLine(userLogin.Name);
        Console.WriteLine(userLogin.Password);
        return Ok();
    }
}
