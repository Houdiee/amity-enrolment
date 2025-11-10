namespace Api.Models.Forms.Enrolment;

public record FamilyDetails
{
    public List<SiblingDetails> StudentSiblings { get; init; } = new();
    public GuardianType? GuardianType { get; init; } = null;
    public bool? HasCustodyRestrictions { get; init; } = null;
    public string? CustodyRestrictionDocumentURL { get; init; } = null;
    public bool? WillChildUsePrivateBus { get; init; } = null;
    public ParentForm? FatherForm { get; init; } = null;
    public ParentForm? MotherForm { get; init; } = null;
}

public record SiblingDetails
{
    public string? Name { get; init; } = null;
    public int? Age { get; init; } = null;
    public int? Grade { get; init; } = null;
    public string? SchoolCurrentlyAttending { get; init; } = null;
}

public enum GuardianType
{
    BothParents,
    Mother,
    Father,
    Guardian,
}

public record ParentForm
{
    public bool? isAmityGraduate { get; init; } = null;
    public int? AmityGraduateYear { get; init; } = null;
    public string? Title { get; init; } = null;
    public string? GivenName { get; init; } = null;
    public string? RelationshipToChild { get; init; } = null;
    public string? Address { get; init; } = null;
    public string? Suburb { get; init; } = null;
    public int? Postcode { get; init; } = null;
    public string? Mobile { get; init; } = null;
    public string? HomePhone { get; set; } = null;
    public string? WorkPhone { get; init; } = null;
    public string? Email { get; init; } = null;
    public string? CountryOfBirth { get; init; } = null;
    public string? EthnicBackground { get; init; } = null;
    public List<string> LanguagesSpokenAtHome { get; init; } = new();
    public LowestEducationLevel? LowestEducationLevel { get; init; } = null;
    public HighestEducationLevel? HighestEducationLevel { get; init; } = null;
    public string? CurrentOccupation { get; init; } = null;
    public int? OccupationGroup { get; init; } = null;
    public string? CompanyName { get; init; } = null;
}

public enum LowestEducationLevel
{
    BelowYear10,
    Year10,
    Year12,
}

public enum HighestEducationLevel
{
    Bachelor,
    Diploma,
    Certificate,
    None,
}
