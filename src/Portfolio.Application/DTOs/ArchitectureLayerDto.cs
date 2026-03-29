namespace Portfolio.Application.DTOs;

public record ArchitectureLayerDto(
    int Id,
    string Name,
    string Description,
    string CodeSnippet,
    string Language,
    string? GitHubFileUrl,
    int Order
);
