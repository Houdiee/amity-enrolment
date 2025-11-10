namespace Api.Models.Forms.Enrolment;

public record BillingAddress
{
    public string? Title { get; init; } = null;
    public string? GivenNames { get; init; } = null;
    public string? FamilyName { get; init; } = null;
    public string? Address { get; init; } = null;
    public string? Suburb { get; init; } = null;
    public int? Postcode { get; init; } = null;
    public string? State { get; init; } = null;
    public string? Email { get; init; } = null;
    public string? MobilePhone { get; init; } = null;
    public string? HomePhone { get; init; } = null;
}
