namespace butterfly_dotnet_mvc.Models;

public class User : CoreEntity
{
    // the "null!" is called "null-forgiving" operator, it suppress nullable warnings at compile analysis flow
    // Source: "https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving"
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; } = new List<Post>();

}
