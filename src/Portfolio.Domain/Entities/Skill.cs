namespace Portfolio.Domain.Entities;

public class Skill
{
    public int Id { get; set; }
    public string NamePt { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string CategoryPt { get; set; } = string.Empty;
    public string CategoryEn { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public int Order { get; set; }
}
