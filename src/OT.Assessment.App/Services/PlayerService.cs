using AutoMapper;
using Microsoft.Identity.Client;
using OT.Assessment.App.AsyncDataServices.Interfaces;
using OT.Assessment.App.Data.Interface;
using OT.Assessment.App.Models;
using OT.Assessment.App.Models.DTOs;
using OT.Assessment.App.Services.Interfaces;

namespace OT.Assessment.App.Services
{
  public class PlayerService : IPlayerService
  {
    private readonly IMapper _mapper;
    private readonly IMessageBusClient _messageBusClient;
    private readonly IPlayerRepo _repository;

    public PlayerService(
          IMapper mapper,
          IMessageBusClient messageBusClient, IPlayerRepo repository)
    {
      _mapper = mapper;
      _messageBusClient = messageBusClient;
      _repository = repository;
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

    public async Task<BaseResponseDTO> GetCasinoWagersForPlayer(Guid AccountID, int pageNumber = 1, int pageSize = 10)
    {
      BaseResponseDTO responseDTO =  new BaseResponseDTO();
      var response = await _repository.GetCasinoWagersForPlayer(AccountID,pageNumber,pageSize);


      if (response != null)
      {
        responseDTO.IsSuccess = true;
        //should map here just not working with page list dont know why but should get the idea 
        //responseDTO.Result = _mapper.Map<PagedList<WagerResultDTO>>(response);
        responseDTO.Result = response;

        return  responseDTO;
      }

      return null;
    }

    public async Task<BaseResponseDTO> getTopSpenderstTopSpenders(int count)
    {
      BaseResponseDTO responseDTO = new BaseResponseDTO();
      var response = await _repository.getTopSpenders(count);
      if (response != null)
      {
        responseDTO.IsSuccess = true;
        responseDTO.Result = response;

        return responseDTO;
      }

      return null;
    }
  }
}
