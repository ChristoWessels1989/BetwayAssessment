using System.ComponentModel.DataAnnotations;

namespace OT.Assessment.App.Models
{
  public class Provider
  {
    [Key]
    [Required]
    public string Name { get; set; }
    [Required]
    public List<Game> Games { get; set; }


  }
}
