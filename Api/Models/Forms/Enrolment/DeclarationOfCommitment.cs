namespace Api.Models.Forms.Enrolment;

public record DeclarationOfCommitment {
  public bool? AgreeInformationCorrect { get; init; } = null;
  public bool? AgreeMedicalInformationFullyDisclosed { get; init; } = null;
  public bool? AgreeNotGuarantee { get; init; } = null;
  public bool? AgreeBoundByCoE { get; init; } = null;
  public bool? AgreeAmityCollege { get; init; } = null;
  public string? FatherSignatureURL { get; init; } = null;
  public string? MotherSignatureURL { get; init; } = null;
  public DateOnly? Date { get; init; } = null;
}
