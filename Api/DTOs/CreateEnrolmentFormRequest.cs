using Api.Models.Forms.Enrolment;

namespace Api.DTOs;

public record CreateEnrolmentFormRequest {
  public required StudentDetails StudentDetails { get; init; }
  public required StudentSchoolingExperience StudentSchoolingExperience { get; init; }
  public required FamilyDetails FamilyDetails { get; init; }
  public required DocumentChecklist DocumentChecklist { get; init; }
  public required MedicalInformation MedicalInformation { get; init; }
  public required List<EmergencyContactDetail> EmergencyContactDetails { get; init; }
  public required BillingAddress BillingAddress { get; init; }
  public required DeclarationOfCommitment DeclarationOfCommitment { get; init; }
  public required Feedback Feedback { get; init; }
}
