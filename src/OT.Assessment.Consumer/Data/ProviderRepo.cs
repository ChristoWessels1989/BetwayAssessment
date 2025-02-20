using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OT.Assessment.Consumer.Data.Interface;
using OT.Assessment.Consumer.Models;

namespace OT.Assessment.Consumer.Data
{
  public class ProviderRepo : IProviderRepo
  {
    private readonly AppDBContext _appDBContext;

    public ProviderRepo(AppDBContext appDBContext)
    {
      _appDBContext = appDBContext;
    }

    public bool CheckIfExists(string Name)
    {
      return _appDBContext.Providers.Any(p => p.Name == Name);
    }

    public Provider CreateRecord(Provider obj)
    {
      if (obj == null)
      {
        throw new ArgumentNullException(nameof(obj));
      }

      _appDBContext.Providers.Add(obj);

      return obj;
    }

    public bool SaveChanges()
    {
      return (_appDBContext.SaveChanges() >= 0);
    }
  }
}
