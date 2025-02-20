using System.ComponentModel.DataAnnotations;

namespace OT.Assessment.Consumer.Models
{
  public class Provider
  {
    [Key]
    [Required]
    public string Name { get; set; }
    public List<Game> Games { get; set; }


  }
}
