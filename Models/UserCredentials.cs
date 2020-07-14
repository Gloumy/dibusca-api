using System.ComponentModel.DataAnnotations;

namespace dibusca_api.Models
{
  public class UserCredentials
  {
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }

  }
}