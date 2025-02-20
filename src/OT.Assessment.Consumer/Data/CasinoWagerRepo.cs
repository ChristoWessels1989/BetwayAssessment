using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OT.Assessment.Consumer.Data.Interface;
using OT.Assessment.Consumer.Models;

namespace OT.Assessment.Consumer.Data
{
  public class CasinoWagerRepo : ICasinoWagerRepo
  {
    private readonly AppDBContext _appDBContext;

    public CasinoWagerRepo(AppDBContext appDBContext)
    {
      _appDBContext = appDBContext;
    }

    public bool CheckIfExists(Guid WagerId)
    {
      return _appDBContext.CasinoWagers.Any(p => p.WagerId == WagerId);
    }

    public CasinoWager CreateRecord(CasinoWager obj)
    {
      if (obj == null)
      {
        throw new ArgumentNullException(nameof(obj));
      }

      _appDBContext.CasinoWagers.Add(obj);

      return obj;
    }


    public bool SaveChanges()
    {
      return (_appDBContext.SaveChanges() >= 0);
    }
  }
}
