namespace Portfolio.Domain.Entities;

public class Certification
{
    public int Id { get; set; }
    public string NamePt { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public string? CredentialUrl { get; set; }
}
