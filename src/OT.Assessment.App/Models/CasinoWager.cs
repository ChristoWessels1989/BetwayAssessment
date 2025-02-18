using System.ComponentModel.DataAnnotations;

namespace OT.Assessment.App.Models
{
  public class CasinoWager
  {
    [Required]
    public Guid WagerId { get; set; }
    [Required]
    public string Theme { get; set; }
    [Required]
    public string Provider { get; set; }
    [Required]
    public string GameName { get; set; }
    [Required]
    public Guid TransactionId { get; set; }
    [Required]
    public Guid BrandId { get; set; }
    [Required]
    public Guid AccountId { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public Guid ExternalReferenceId { get; set; }
    [Required]
    public Guid TransactionTypeId { get; set; }
    [Required]
    public double Amount { get; set; }
    [Required]
    public DateTime CreatedDateTime { get; set; }
    [Required]
    public int NumberOfBets { get; set; }
    [Required]
    public string CountryCode { get; set; }
    [Required]
    public string SessionData { get; set; }
    [Required]
    public long Duration { get; set; }

    //relationships
    public virtual Player Player { get; set; }
    public virtual Provider GameProvider { get; set; }
    public virtual Game Game { get; set; }

  }
}
