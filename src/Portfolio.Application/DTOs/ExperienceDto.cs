namespace Portfolio.Application.DTOs;

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
