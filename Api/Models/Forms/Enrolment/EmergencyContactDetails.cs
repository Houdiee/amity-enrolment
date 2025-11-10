namespace Api.Models.Forms.Enrolment;

public record EmergencyContactDetail
{
    public string? ContactName { get; init; } = null;
    public string? RelationshipToChild { get; init; } = null;
    public string? MobilePhone { get; init; } = null;
    public string? HomePhone { get; init; } = null;
}

