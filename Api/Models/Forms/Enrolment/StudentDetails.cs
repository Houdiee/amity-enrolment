namespace Api.Models.Forms.Enrolment;

public record StudentDetails
{
    public string? FamilyName { get; init; } = null;
    public string? GivenNames { get; init; } = null;
    public DateOnly? DateOfBirth { get; init; } = null;
    public string? CountryOfBirth { get; init; } = null;
    public string? EthnicBackground { get; init; } = null;
    public string? Religion { get; init; } = null;
    public List<string> LanguagesSpoken { get; init; } = new();
    public List<Campus> CampusApplied { get; init; } = new();
    public IndigenousStatus? IndigenousStatus { get; init; } = null;
    public ResidencyStatus? ResidencyStatus { get; init; } = null;
    public string? PassportNo { get; init; } = null;
    public string? VisaSubclass { get; init; } = null;
    public string? VisaExpires { get; init; } = null;
}

public enum Campus
{
    Prestons,
    Illawara,
    Auburn,
    Leppington,
}

public enum IndigenousStatus
{
    Aboriginal,
    TorresStraitIslander,
    Both,
    None,
}

public enum ResidencyStatus
{
    AustralianCitizen,
    PermanentResident,
    TemporaryResident,
}
