using Microsoft.Extensions.Configuration;
using OT.Assessment.Consumer.AsyncDataServices;
using OT.Assessment.Consumer.Data;
using OT.Assessment.Consumer.Data.Interface;
using OT.Assessment.Consumer.EventProcessing.Interfaces;
using OT.Assessment.Consumer.EventProcessing;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    })
    .ConfigureServices((context, services) =>
    {
      //configure services
      services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(context.Configuration.GetConnectionString("DatabaseConnection")));
      services.AddHostedService<MessageBusSubscriber>();
      services.AddScoped<ICasinoWagerRepo, CasinoWagerRepo>();
      services.AddScoped<IPlayerRepo, PlayerRepo>();
      services.AddScoped<IGameRepo, GameRepo>();
      services.AddScoped<IProviderRepo, ProviderRepo>();
      services.AddSingleton<IEventProcessor, EventProcessor>();
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    })
    .Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application started {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);

await host.RunAsync();

logger.LogInformation("Application ended {time:yyyy-MM-dd HH:mm:ss}", DateTime.Now);