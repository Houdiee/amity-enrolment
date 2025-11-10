namespace Api.Models.Forms.Enrolment;

public record StudentSchoolingExperience
{
    public SchoolAndGrade CurrentSchoolAndGrade { get; init; } = new();
    public List<SchoolAndGrade> PreviousSchoolsAndGrade { get; init; } = new();
    public List<string> Achievements { get; init; } = new();
    public bool? HasChildBeenSuspendedOrWorse { get; init; } = null;
    public string? SuspensionOrWorseDetails { get; init; } = null;
    public Rating? AcademicRating { get; init; } = null;
    public Rating? SocialRating { get; init; } = null;
    public string? ExtraNotes { get; init; } = null;
}

public record SchoolAndGrade
{
    public string? CurrentSchool { get; init; } = null;
    public int? Grade { get; init; } = null;
}

public enum Rating
{
    NeedsImprovement,
    Average,
    Good,
    VeryGood,
}
