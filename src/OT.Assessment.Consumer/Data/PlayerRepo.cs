using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OT.Assessment.Consumer.Data.Interface;
using OT.Assessment.Consumer.Models;

namespace OT.Assessment.Consumer.Data
{
  public class PlayerRepo : IPlayerRepo
  {
    private readonly AppDBContext _appDBContext;

    public PlayerRepo(AppDBContext appDBContext)
    {
      _appDBContext = appDBContext;
    }

    public bool CheckIfExists(Guid AccountID)
    {
      return _appDBContext.Players.Any(p => p.AccountId == AccountID);
    }

    public Player CreateRecord(Player obj)
    {
      if (obj == null)
      {
        throw new ArgumentNullException(nameof(obj));
      }

      _appDBContext.Players.Add(obj);

      return obj;
    }


    public bool SaveChanges()
    {
      return (_appDBContext.SaveChanges() >= 0);
    }
  }
}
