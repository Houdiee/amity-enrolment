using Api.Models.Forms.Enrolment;

namespace Api.DTOs;

public record CreateEnrolmentFormRequest {
  public required StudentDetails StudentDetails { get; set; }
  public required StudentSchoolingExperience StudentSchoolingExperience { get; set; }
  public required FamilyDetails FamilyDetails { get; set; }
  public required DocumentChecklist DocumentChecklist { get; set; }
  public required MedicalInformation MedicalInformation { get; set; }
  public required List<EmergencyContactDetail> EmergencyContactDetails { get; set; }
  public required BillingAddress BillingAddress { get; set; }
  public required DeclarationOfCommitment DeclarationOfCommitment { get; set; }
  public required Feedback Feedback { get; set; }
}
