namespace OT.Assessment.App.Models
{
  public class Provider
  {
    public string Name { get; set; }
    public List<Game> Games { get; set; }

    //Relationships
    public virtual ICollection<Game> LinkedGames { get; set; }

  }
}
