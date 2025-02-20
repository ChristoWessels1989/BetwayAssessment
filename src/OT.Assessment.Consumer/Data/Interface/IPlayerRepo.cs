
using OT.Assessment.Consumer.Models;

namespace OT.Assessment.Consumer.Data.Interface
{
  public interface IPlayerRepo : IEditRepo<Player>
  {
    bool CheckIfExists(Guid AccountID);

  }
}
