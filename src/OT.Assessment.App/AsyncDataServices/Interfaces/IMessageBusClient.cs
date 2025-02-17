using OT.Assessment.App.Models.DTOs;

namespace OT.Assessment.App.AsyncDataServices.Interfaces
{
  public interface IMessageBusClient
  {
    void PublishNewWager(WagerPublishDTO platformPublishedDto);
  }
}
