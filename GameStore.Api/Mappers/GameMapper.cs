using System;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mappers;

public static class GameMapper
{
  public static GameEntity ToEntity(this CreateGameDTO createGameDTO) {
    return new GameEntity() {
      Name = createGameDTO.Name,
      GenreId = createGameDTO.GenreId,
      Price = createGameDTO.Price,
      ReleaseDate = createGameDTO.ReleaseDate
    };
  }

  public static GameEntity ToEntity(this UpdateGameDTO updateGameDTO, int game_id) {
    return new GameEntity() {
      Id = game_id,
      Name = updateGameDTO.Name,
      GenreId = updateGameDTO.GenreId,
      Price = updateGameDTO.Price,
      ReleaseDate = updateGameDTO.ReleaseDate
    };
  }

  public static GameSumaryDTO ToSumaryDTO(this GameEntity gameEntity) {
    return new GameSumaryDTO(
      gameEntity.Id,
      gameEntity.Name,
      gameEntity.Genre!.Name,
      gameEntity.Price,
      gameEntity.ReleaseDate
    );
  }

  public static GameDetailsDTO ToDetailsDTO(this GameEntity gameEntity) {
    return new GameDetailsDTO(
      gameEntity.Id,
      gameEntity.Name,
      gameEntity.GenreId,
      gameEntity.Price,
      gameEntity.ReleaseDate
    );
  }

}
