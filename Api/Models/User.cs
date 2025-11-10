using Api.Models.Forms.Enrolment;

namespace Api.Models;

public class User {
  public int Id { get; set; }
  public required string Email { get; set; }
  public required byte[] HashedPassword { get; set; }

  public int EnrolmentFormId { get; set; }
  public required EnrolmentForm EnrolmentForm { get; set; } = null!;
}
