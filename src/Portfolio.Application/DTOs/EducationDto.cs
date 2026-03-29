namespace Portfolio.Application.DTOs;

public record EducationDto(
    int Id,
    string Institution,
    string Degree,
    string Field,
    int StartYear,
    int EndYear
);
