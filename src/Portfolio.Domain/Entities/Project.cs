namespace Portfolio.Domain.Entities;

public class Project
{
    public int Id { get; set; }
    public string TitlePt { get; set; } = string.Empty;
    public string TitleEn { get; set; } = string.Empty;
    public string DescriptionPt { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public List<string> Technologies { get; set; } = [];
    public string? GitHubUrl { get; set; }
    public string? LiveUrl { get; set; }
    public int Order { get; set; }
}
