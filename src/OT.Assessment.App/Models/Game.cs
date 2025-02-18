using System.ComponentModel.DataAnnotations;

namespace OT.Assessment.App.Models
{
  public class Game
  {
    //did not add a ID field but it should be done actually for test purposes no need 
    [Key]
    [Required]
    public string Name { get; set; }
    [Required]
    public string Theme { get; set; }
  }
}
