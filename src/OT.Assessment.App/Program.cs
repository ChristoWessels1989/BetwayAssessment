using OT.Assessment.App.AsyncDataServices.Interfaces;
using OT.Assessment.App.AsyncDataServices;
using System.Reflection;
using OT.Assessment.App.Services.Interfaces;
using OT.Assessment.App.Services;
using OT.Assessment.App.Data;
using Microsoft.EntityFrameworkCore;
using OT.Assessment.App.Data.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDBContext>(option =>
{
  option.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckl
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPlayerRepo, PlayerRepo>();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts =>
    {
        opts.EnableTryItOutByDefault();
        opts.DocumentTitle = "OT Assessment App";
        opts.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
ApplyMigration(); // Apply Data Migrations here 
app.Run();

//Data migration
void ApplyMigration()
{
  using (var scope = app.Services.CreateScope())
  {
    var _db = scope.ServiceProvider.GetRequiredService<AppDBContext>();

    if (_db.Database.GetPendingMigrations().Any())
    {
      _db.Database.Migrate();
    }
  }
}