using Microsoft.EntityFrameworkCore;
using OT.Assessment.App.Data.Interface;
using OT.Assessment.App.Models;

namespace OT.Assessment.App.Data
{
  public class PlayerRepo : IPlayerRepo
  {
    private readonly AppDBContext _appDBContext;

    public PlayerRepo(AppDBContext appDBContext)
    {
      _appDBContext = appDBContext;
    }

    public async Task<IEnumerable<CasinoWager>> GetCasinoWagersForPlayer(int pageNumber = 1, int pageSize = 10, Guid AccountID)
    {
      var data = await _appDBContext.CasinoWagers
       .Where(d => d.AccountId > AccountID)
       .OrderBy(d => d.WagerId)

       .Skip((pageNumber - 1) * pageSize)

       .Take(pageSize)

       .ToListAsync();

      return data;
    }

    public IEnumerable<Player> getTopSpenders(int count)
    {
      throw new NotImplementedException();
    }
  }
}
