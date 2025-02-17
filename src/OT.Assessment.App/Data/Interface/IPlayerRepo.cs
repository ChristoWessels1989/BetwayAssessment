using OT.Assessment.App.Models;

namespace OT.Assessment.App.Data.Interface
{
  public interface IPlayerRepo
  {
    public Task<IEnumerable<Player>> getTopSpenders(int count);
    public Task<IEnumerable<CasinoWager>>  GetCasinoWagersForPlayer(int pageNumber = 1, int pageSize = 10);
  }
}
