using System;
using GameStore.Api.Data;
using GameStore.Api.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.EndPoints;

public static class GenreEndpoint
{
  public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app) {

    var group = app.MapGroup("genres");

    group.MapGet("/", async (GameStoreContext dbContext) => 
      await dbContext.Genres
                      .Select(genre => genre.ToDTO())
                      .AsNoTracking()
                      .ToListAsync()
    );

    return group;

  }
}
