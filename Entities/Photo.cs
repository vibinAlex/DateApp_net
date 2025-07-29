using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public required string Url { get; set; }
    public bool IsMain { get; set; }
    public string? PublicID { get; set; }

    //Navigation properties /Required One to many relationship
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
}