namespace Portfolio.Application.DTOs;

public record SkillDto(
    int Id,
    string Name,
    string Category,
    string Icon,
    int Order
);
