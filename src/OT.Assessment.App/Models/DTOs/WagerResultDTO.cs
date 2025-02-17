namespace OT.Assessment.App.Models.DTOs
{
  public class WagerResultDTO
  {
    public Guid WagerId { get; set; }
    public string Game { get; set; }
    public string Provider { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedDateTime { get; set; }
  }
}
