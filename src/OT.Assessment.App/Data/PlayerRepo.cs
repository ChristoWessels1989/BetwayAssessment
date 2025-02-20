using Microsoft.EntityFrameworkCore;
using OT.Assessment.App.Data.Interface;
using OT.Assessment.App.Extensions;
using OT.Assessment.App.Models;
using System.Collections.Generic;

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
      var result = (from cw in _appDBContext.CasinoWagers
                    join p in _appDBContext.Players on cw.AccountId equals p.AccountId
                    group new { cw, p } by new { cw.AccountId, p.Username } into g
                    select new
                    {
                      g.Key.AccountId,
                      g.Key.Username,
                      TotalAmountSpend = g.Sum(x => x.cw.Amount)
                    }).Take(10).ToList();

      //doing this stupid way of converstion here because casting is not working for some reason
      List<TopSpender> results = new List<TopSpender>();
      foreach (var cw in result)
      {
        TopSpender top =  new TopSpender();
        top.AccountId = cw.AccountId;
        top.Username = cw.Username;
        top.TotalAmountSpend = cw.TotalAmountSpend;
        results.Add(top);
      }

      return results;

    }
  }
}
