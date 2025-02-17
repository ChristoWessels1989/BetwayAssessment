using OT.Assessment.App.Models.DTOs;

namespace OT.Assessment.App.Services.Interfaces
{
  public interface IPlayerService
  {
    Task<BaseResponseDTO> CreateWager(WagerPublishDTO wagerPublishDTO);

  }
}
