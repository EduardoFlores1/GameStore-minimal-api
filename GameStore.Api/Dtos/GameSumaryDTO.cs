namespace GameStore.Api.Dtos;

public record class GameSumaryDTO(
  int Id,
  string Name,
  string Genre,
  decimal Price,
  DateOnly ReleaseDate
);