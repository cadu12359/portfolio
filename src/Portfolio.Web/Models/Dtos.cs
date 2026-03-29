namespace Portfolio.Web.Models;

public record ExperienceDto(
    int Id,
    string Company,
    string Role,
    string Description,
    DateTime StartDate,
    DateTime? EndDate,
    bool IsCurrent,
    List<string> Technologies,
    int Order
);

public record SkillDto(
    int Id,
    string Name,
    string Category,
    string Icon,
    int Order
);

public record ProjectDto(
    int Id,
    string Title,
    string Description,
    List<string> Technologies,
    string? GitHubUrl,
    string? LiveUrl,
    int Order
);

public record CertificationDto(
    int Id,
    string Name,
    string Issuer,
    DateTime IssueDate,
    string? CredentialUrl
);

public record EducationDto(
    int Id,
    string Institution,
    string Degree,
    string Field,
    int StartYear,
    int EndYear
);

public record ArchitectureLayerDto(
    int Id,
    string Name,
    string Description,
    string CodeSnippet,
    string Language,
    string? GitHubFileUrl,
    int Order
);
