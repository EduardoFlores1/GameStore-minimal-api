using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.EndPoints;

public static class GameEndPoint
{
  const string GetGameEndPointName = "GetGame";

  public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
  {

    var group = app.MapGroup("games")
                  .WithParameterValidation();

    // Get All Games
    group.MapGet("/", async (GameStoreContext dbContext) => 
      await dbContext.Games
                .Include(game => game.Genre)
                .Select(game => game.ToSumaryDTO())
                .AsNoTracking()
                .ToListAsync()
    );

    // Get One Game
    group.MapGet("/{game_id}", async (int game_id, GameStoreContext dbContext) =>
    {
      GameEntity? game = await dbContext.Games.FindAsync(game_id);
      return game is null ? Results.NotFound() : Results.Ok(game.ToDetailsDTO());

    })
    .WithName(GetGameEndPointName);

    // Create Game
    group.MapPost("/", async (CreateGameDTO createDTO, GameStoreContext dbContext) =>
    {
      
      GameEntity entity = createDTO.ToEntity();
      dbContext.Games.Add(entity);
      await dbContext.SaveChangesAsync();

      return Results
      .CreatedAtRoute(GetGameEndPointName, new { game_id = entity.Id }, entity.ToDetailsDTO());
    });

    // Update Game
    group.MapPut("/{game_id}", async (int game_id, UpdateGameDTO updateDTO, GameStoreContext dbContext) =>
    {
      GameEntity? gameFound = await dbContext.Games.FindAsync(game_id);
      if (gameFound is null) return Results.NotFound();

      dbContext.Entry(gameFound)
        .CurrentValues
        .SetValues(updateDTO.ToEntity(game_id));
      
      await dbContext.SaveChangesAsync();

      return Results.Ok();

    });

    // Delete Game
    group.MapDelete("/{game_id}", async (int game_id, GameStoreContext dbContext) =>
    {
      await dbContext.Games
                .Where(game => game.Id == game_id)
                .ExecuteDeleteAsync();

      return Results.NoContent();
    });

    return group;
  }
}
