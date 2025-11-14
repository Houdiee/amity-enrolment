using Api.Models;

namespace Api.DTOs;

public record UserResponse
{
    public required int Id { get; init; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required int EnrolmentFormId { get; init; }

    public static UserResponse FromEntity(User user)
    {
        return new UserResponse()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            EnrolmentFormId = user.EnrolmentForm.Id,
        };
    }
}
