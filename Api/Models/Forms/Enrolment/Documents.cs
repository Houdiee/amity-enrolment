namespace Api.Models.Forms.Enrolment;

public record DocumentChecklist {
  public string? BirthCertificateURL { get; init; } = null;
  public string? ImmunisationHistoryReportURL { get; init; } = null;
  public string? ChildPhotoURL { get; init; } = null;
  public string? ParentPhotoURL { get; init; } = null;
  public string? VisaPaperworkURL { get; init; } = null;
}
// TODO: Add payment system
