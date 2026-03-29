namespace Portfolio.Application.DTOs;

public record CertificationDto(
    int Id,
    string Name,
    string Issuer,
    DateTime IssueDate,
    string? CredentialUrl
);
