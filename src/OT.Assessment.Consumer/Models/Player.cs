using System.ComponentModel.DataAnnotations;

namespace OT.Assessment.Consumer.Models
{
  public class Player
  {
    [Key]
    [Required]
    public Guid AccountId { get; set; }
    [Required]
    public string Username { get; set; }

    //relationships
  public virtual ICollection<CasinoWager> CasinoWagers {  get; set; }
  }
}
