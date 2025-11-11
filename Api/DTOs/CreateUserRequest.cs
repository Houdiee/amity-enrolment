namespace Api.DTOs;

public record CreateUserRequest {
  public required string Email { get; set; }
  public required string Password { get; set; }
}
