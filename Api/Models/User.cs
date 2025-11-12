using Api.Models.Forms.Enrolment;
using Newtonsoft.Json;

namespace Api.Models;

public class User
{
    public int Id { get; }
    public required string Email { get; set; }
    [JsonIgnore] 
    public byte[] HashedPassword { get; set; } = null!;
    public required EnrolmentForm EnrolmentForm { get; set; } = null!;
}
