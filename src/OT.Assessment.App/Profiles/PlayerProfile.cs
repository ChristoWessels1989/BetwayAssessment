using AutoMapper;
using OT.Assessment.App.Models;
using OT.Assessment.App.Models.DTOs;

namespace OT.Assessment.App.Profiles
{
  public class PlayerProfile : Profile
  {
    public PlayerProfile()
    {
      CreateMap<WagerPublishDTO, CasinoWager>();

    }
  }
}
