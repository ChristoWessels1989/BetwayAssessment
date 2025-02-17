using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using OT.Assessment.App.AsyncDataServices.Interfaces;
using OT.Assessment.App.Data.Interface;
using OT.Assessment.App.Models.DTOs;
using OT.Assessment.App.Services.Interfaces;
namespace OT.Assessment.App.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlayerController : ControllerBase
  {
    private readonly IPlayerService _service;

    public PlayerController(IPlayerService service)
    {
      _service = service;
    }

    //POST api/player/casinowager
    [HttpPost]
    [Route("CasinoWager")]

    public async Task<ActionResult<BaseResponseDTO>> CreateWager(WagerPublishDTO wagerPublishDTO)
    {
      var Response = await _service.CreateWager(wagerPublishDTO);
      if (Response == null)
      {
        Response.IsSuccess = false;
        Response.Message = "Error Adding Wager";
        return BadRequest(Response);
      }

      Response.Result = Response;

      return Ok(Response);
    }


    //GET api/player/{playerId}/wagers
    [HttpGet("{playerId}/casino")]
    public async Task<ActionResult<BaseResponseDTO>> GetPlayerWagers(int pageNumber = 1, int pageSize = 10)
    {
      return Ok();

    }
    //GET api/player/topSpenders?count=10
    [HttpGet("topSpenders")]
    public async Task<ActionResult<BaseResponseDTO>> GetPlayerWagers(int count = 10)
    {
      return Ok();

    }
  }
}
