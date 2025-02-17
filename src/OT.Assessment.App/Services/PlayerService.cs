using AutoMapper;
using OT.Assessment.App.AsyncDataServices.Interfaces;
using OT.Assessment.App.Models;
using OT.Assessment.App.Models.DTOs;
using OT.Assessment.App.Services.Interfaces;

namespace OT.Assessment.App.Services
{
  public class PlayerService : IPlayerService
  {
    private readonly IMapper _mapper;
    private readonly IMessageBusClient _messageBusClient;
    public PlayerService(
          IMapper mapper,
          IMessageBusClient messageBusClient)
    {
      _mapper = mapper;
      _messageBusClient = messageBusClient;
    }
    public async Task<BaseResponseDTO> CreateWager(WagerPublishDTO wagerPublishDTO)
    {
      var response = new BaseResponseDTO();
      var casinoWager = _mapper.Map<CasinoWager>(wagerPublishDTO);

      //Send Async Message
      try
      {
        _messageBusClient.PublishNewWager(casinoWager);
        response.IsSuccess = true;
        response.Message = $"Wager with ID :{casinoWager.WagerId} published";

      }
      catch (Exception ex)
      {
        response.IsSuccess = false;
        response.Message = $"Wager with ID :{casinoWager.WagerId} failed to publish";
      }

      return response;
    }
  }
}
