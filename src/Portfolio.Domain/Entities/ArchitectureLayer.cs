namespace Portfolio.Domain.Entities;

public class ArchitectureLayer
{
    public int Id { get; set; }
    public string NamePt { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string DescriptionPt { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public string CodeSnippet { get; set; } = string.Empty;
    public string Language { get; set; } = "csharp";
    public string? GitHubFileUrl { get; set; }
    public int Order { get; set; }
}
