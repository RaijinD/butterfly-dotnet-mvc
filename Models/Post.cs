namespace butterfly_dotnet_mvc.Models;

public class Post : CoreEntity
{
    public string Title { get; set; } = null!;

    public virtual User Owner { get; set; } = null!;

    public int OwnerId { get; set; } 

    public string content { get; set; } = null!;

}
