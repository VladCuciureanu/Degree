using Microsoft.AspNetCore.Identity;

namespace AudioStreaming.Models
{
  public class User : IdentityUser
  {
    public string? ImageUrl { get; set; } = null;
  }
}
