using Microsoft.EntityFrameworkCore;
using OT.Assessment.App.Data.Interface;
using OT.Assessment.App.Extensions;
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

    public async Task<PagedList<CasinoWager>> GetCasinoWagersForPlayer( Guid AccountID,int pageNumber = 1, int pageSize = 10)
    {
      var data = await _appDBContext.CasinoWagers
     .Where(d => d.AccountId > AccountID)
     .OrderBy(d => d.WagerId)
     .ToPagedListAsync(pageNumber, pageSize);

      return data;
    }

    public async Task<IEnumerable<TopSpender>> getTopSpenders(int count)
    {
      var  topSpenders = await _appDBContext.Players
    .Join(
        _appDBContext.CasinoWagers,
        f => f.AccountId,
        d => d.AccountId,
        (f, d) => new { f.AccountId,f.Username,d.Amount })
    .GroupBy(f =>  new { f.AccountId,f.Username })
    .Select(x => new { x.Key.AccountId, x.Key.Username, TotalAmountSpend = x.Select(g => g.Amount).Sum() })
    .OrderByDescending(x=> x.TotalAmountSpend)
    .Take(count)
    .ToListAsync();

      return (IEnumerable<TopSpender>)topSpenders;

    }
  }
}
