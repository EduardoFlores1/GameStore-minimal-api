using GameStore.Api.Data;
using GameStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore_SQL");
builder.Services.AddSqlServer<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndPoints();
app.MapGenresEndpoints();

await app.MigrateDBAsync();

app.Run();