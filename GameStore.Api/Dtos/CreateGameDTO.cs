using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class CreateGameDTO(
  [Required][StringLength(50)] string Name,
  [Required] int GenreId,
  [Range(1, 500)]decimal Price,
  [Required]DateOnly ReleaseDate
);
