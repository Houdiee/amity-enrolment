namespace Api.DTOs;

public record CreateUserRequest {
  public required string Email { get; init; }
  public required string Password { get; init; }
}
