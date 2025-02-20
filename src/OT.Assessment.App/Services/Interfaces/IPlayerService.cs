using OT.Assessment.App.Models.DTOs;

namespace OT.Assessment.App.Services.Interfaces
{
  public interface IPlayerService
  {
    Task<BaseResponseDTO> CreateWager(WagerPublishDTO wagerPublishDTO);

    Task<BaseResponseDTO> getTopSpenderstTopSpenders(int count);
    Task<BaseResponseDTO> GetCasinoWagersForPlayer(Guid AccountID, int pageNumber = 1, int pageSize = 10);


  }
}
