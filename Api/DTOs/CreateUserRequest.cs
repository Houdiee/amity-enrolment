namespace Api.DTOs;

public record CreateUserRequest {
  public required string FirstName { get; init; }
  public required string LastName { get; init; }
  public required string Email { get; init; }
  public required string Password { get; init; }
}
