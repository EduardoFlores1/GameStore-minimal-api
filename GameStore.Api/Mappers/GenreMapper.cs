using System;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mappers;

public static class GenreMapper
{
  public static GenreDTO ToDTO(this GenreEntity genreEntity) {
    return new GenreDTO(genreEntity.Id, genreEntity.Name);
  }
}
