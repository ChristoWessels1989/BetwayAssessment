using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OT.Assessment.Consumer.Data.Interface;
using OT.Assessment.Consumer.Models;

namespace OT.Assessment.Consumer.Data
{
  public class GameRepo : IGameRepo
  {
    private readonly AppDBContext _appDBContext;

    public GameRepo(AppDBContext appDBContext)
    {
      _appDBContext = appDBContext;
    }

    public bool CheckIfExists(string Name, string ProviderName)
    {
      return _appDBContext.Games.Where(p => p.ProviderName == ProviderName).Any(p => p.Name == Name);       
    }

    public Game CreateRecord(Game obj)
    {
      if (obj == null)
      {
        throw new ArgumentNullException(nameof(obj));
      }

      _appDBContext.Games.Add(obj);

      return obj;
    }


    public bool SaveChanges()
    {
      return (_appDBContext.SaveChanges() >= 0);
    }
  }
}
