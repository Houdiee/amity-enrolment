using Api.Models.Forms.Enrolment;
using System.Text.Json.Serialization;

namespace Api.Models;

public class User
{
    public int Id { get; set; }
    public required string Email { get; set; }
    [JsonIgnore] public byte[] HashedPassword { get; set; } = null!;
    public required EnrolmentForm EnrolmentForm { get; set; } = null!;
}
