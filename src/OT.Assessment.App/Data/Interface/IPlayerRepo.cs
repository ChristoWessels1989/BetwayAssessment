using OT.Assessment.App.Models;

namespace OT.Assessment.App.Data.Interface
{
  public interface IPlayerRepo
  {
    public Task<IEnumerable<TopSpender>> getTopSpenders(int count);
    public Task<PagedList<CasinoWager>> GetCasinoWagersForPlayer(Guid AccountID, int pageNumber = 1, int pageSize = 10);
  }
}
