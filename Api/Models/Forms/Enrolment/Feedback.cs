namespace Api.Models.Forms.Enrolment;

public record Feedback {
  public List<LearnAboutAmityMethod> LearnAboutAmityMethods { get; init; } = new();
  public string? LearnAboutAmityMethodOther { get; init; } = null;
  public List<PromptToApplyForEnrolment> PromptToApplyForEnrolments { get; init; } = new();
  public string? PromptToApplyForEnrolmentOther { get; init; } = null;
}

public enum LearnAboutAmityMethod {
  AmitycollegeParents,
  FamilyFriends,
  PastStudents,
  SchoolListings,
  NewspaperAdvertisement,
  SocialMediaAdvertisement,
  SchoolWebpage,
  Other,
}

public enum PromptToApplyForEnrolment {
  ReputationOfAmity,
  AcademicExcellence,
  ExtracurricularActivities,
  SchoolValues,
  PastoralCare,
  ContinuingFamilyTradition,
  CloseToHome,
  Other,
}
