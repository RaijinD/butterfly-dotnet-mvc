using System.ComponentModel.DataAnnotations;

namespace butterfly_dotnet_mvc.Models;

public class CoreEntity
{
    [Key]
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
}
