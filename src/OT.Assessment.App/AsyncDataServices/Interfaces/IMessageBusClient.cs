using OT.Assessment.App.Models;

namespace OT.Assessment.App.AsyncDataServices.Interfaces
{
  public interface IMessageBusClient
  {
    void PublishNewWager(CasinoWager platformPublishedDto);
  }
}
