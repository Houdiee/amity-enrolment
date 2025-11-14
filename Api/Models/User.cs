using Api.Models.Forms.Enrolment;

namespace Api.Models;

public class User
{
    public int Id { get; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string HashedPassword { get; set; } = null!;
    public required EnrolmentForm EnrolmentForm { get; set; } = null!;
}
