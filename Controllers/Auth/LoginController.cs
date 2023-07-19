using System.Diagnostics;
using butterfly_dotnet_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace butterfly_dotnet_mvc;

public class LoginController : Controller 
{
    private readonly ILogger<LoginController> _logger;

    public IActionResult Index()
    {
        Console.WriteLine("Reached!");
        return View("/Views/Login/Index.cshtml");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
