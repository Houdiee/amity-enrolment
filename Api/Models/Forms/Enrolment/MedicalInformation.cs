namespace Api.Models.Forms.Enrolment;

public record MedicalInformation
{
    public int? MedicareNumber { get; init; } = null;
    public int? RefNo { get; init; } = null;
    public bool? StudentHasPrivateHealthCover { get; init; } = null;
    public string? PrivateHealthCoverDetails { get; init; } = null;
    public bool? StudentHasAmbulanceCover { get; init; } = null;
    public string? AmbulanceCoverDetails { get; init; } = null;
    public string? NameOfFamilyDoctor { get; init; } = null;
    public string? FamilyDoctorPhone { get; init; } = null;
    public string? ClinicAddress { get; init; } = null;
    public List<string> Allergies { get; init; } = new();
    public List<string> MedicalConditions { get; init; } = new();
    public string? ImmunisationRecord { get; init; } = null;
}
