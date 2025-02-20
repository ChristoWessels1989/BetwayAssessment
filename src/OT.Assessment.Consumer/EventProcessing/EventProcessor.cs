using System;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OT.Assessment.Consumer.Data.Interface;
using OT.Assessment.Consumer.EventProcessing.Interfaces;
using OT.Assessment.Consumer.Models;

namespace OT.Assessment.Consumer.EventProcessing
{
  public class EventProcessor : IEventProcessor
  {
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IMapper _mapper;

    public EventProcessor(IServiceScopeFactory scopeFactory, AutoMapper.IMapper mapper)
    {
      _scopeFactory = scopeFactory;
      _mapper = mapper;
    }

    public void ProcessEvent(string message)
    {
      //this can be extended with a switch and eventType added to DTO coming from message queue 
      //for purpose of assessment just reading all messages 

      //var eventType = DetermineEvent(message);

      //switch (eventType)
      //{
      //  case EventType.CasinoWagerAdded:
      //    addCasinoWager(message);
      //    break;
      //  default:
      //    break;
      //}

          addCasinoWager(message);

    }

    private void addCasinoWager(string casinoWager)
    {
      using (var scope = _scopeFactory.CreateScope())
      {
        var CasinoWagerRepo = scope.ServiceProvider.GetRequiredService<ICasinoWagerRepo>();
        var PlayerRepo = scope.ServiceProvider.GetRequiredService<IPlayerRepo>();
        var ProviderRepo = scope.ServiceProvider.GetRequiredService<IProviderRepo>();
        var GameRepo = scope.ServiceProvider.GetRequiredService<IGameRepo>();

        var casinoWagerObj = JsonSerializer.Deserialize<CasinoWager>(casinoWager);

        try
        {
          //first of in a production system i will not add players etc as the wager comes in rather do checks the the player exist as example 
          //if (!repo.ExternalPlayerExists(player.accountID))
          //{
          //  repo.createWager(casinoWagerObj);
          //  repo.SaveChanges();
          //  Console.WriteLine("--> casinoWager added!");
          //}
          //else
          //{
          //  Console.WriteLine("--> casinoWager already exisits...");
          //}


          //this is where all the magic happen
          //so for test purposes will add player provider and game to tables first 
          // then add the wager to the table as well

          if (!ProviderRepo.CheckIfExists(casinoWagerObj.Provider))
          {
            Console.WriteLine($"--> Provider not found adding to Repo");

            Provider provider = new Provider();
            provider.Name = casinoWagerObj.Provider;

            Game game = new Game();
            game.Name = casinoWagerObj.GameName;
            game.Theme = casinoWagerObj.Theme;

            if(provider.Games == null)
            {
              provider.Games = new List<Game>();
            }
            provider.Games.Add(game);

            ProviderRepo.CreateRecord(provider);
            ProviderRepo.SaveChanges();

            Console.WriteLine($"--> Provider added to repo");
          }

          if (!GameRepo.CheckIfExists(casinoWagerObj.GameName,casinoWagerObj.Provider))
          {
            Console.WriteLine($"--> game not found adding to Repo");

            Game game = new Game();
            game.Name = casinoWagerObj.GameName;
            game.Theme = casinoWagerObj.Theme;
            game.ProviderName = casinoWagerObj.Provider;

            GameRepo.CreateRecord(game);
            GameRepo.SaveChanges();

            Console.WriteLine($"--> game added to repo");
          }

          if (!PlayerRepo.CheckIfExists(casinoWagerObj.AccountId))
          {
            Console.WriteLine($"--> Player not found adding to Repo");

            Player player = new Player();
            player.AccountId = casinoWagerObj.AccountId;
            player.Username = casinoWagerObj.Username;

            PlayerRepo.CreateRecord(player);
            PlayerRepo.SaveChanges();

            Console.WriteLine($"--> Player added to repo");
          }

          if (!CasinoWagerRepo.CheckIfExists(casinoWagerObj.WagerId))
          {
            Console.WriteLine($"--> wager not found adding to Repo");

            CasinoWagerRepo.CreateRecord(casinoWagerObj);
            CasinoWagerRepo.SaveChanges();

            Console.WriteLine($"--> wager added to repo");
          }

        }
        catch (Exception ex)
        {
          Console.WriteLine($"--> Could not add Casino Wager to DB {ex.Message}");
        }
      }
    }
  }
}
