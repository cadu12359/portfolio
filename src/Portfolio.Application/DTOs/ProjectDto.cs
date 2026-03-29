namespace Portfolio.Application.DTOs;

public record ProjectDto(
    int Id,
    string Title,
    string Description,
    List<string> Technologies,
    string? GitHubUrl,
    string? LiveUrl,
    int Order
);
