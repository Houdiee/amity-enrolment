using Newtonsoft.Json;

namespace Api.Models.Forms.Enrolment;

public class EnrolmentForm
{
    public int Id { get; }
    public int UserId { get; set; }
    public StudentDetails StudentDetails { get; set; } = new();
    public StudentSchoolingExperience StudentSchoolingExperience { get; set; } = new();
    public FamilyDetails FamilyDetails { get; set; } = new();
    public DocumentChecklist DocumentChecklist { get; set; } = new();
    public MedicalInformation MedicalInformation { get; set; } = new();
    public List<EmergencyContactDetail> EmergencyContactDetails { get; set; } = new();
    public BillingAddress BillingAddress { get; set; } = new();
    public DeclarationOfCommitment DeclarationOfCommitment { get; set; } = new();
    public Feedback Feedback { get; set; } = new();
    [JsonIgnore]
    public User User { get; set; } = null!;
}
