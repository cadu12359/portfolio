namespace Portfolio.Domain.Entities;

public class Experience
{
    public int Id { get; set; }
    public string Company { get; set; } = string.Empty;
    public string RolePt { get; set; } = string.Empty;
    public string RoleEn { get; set; } = string.Empty;
    public string DescriptionPt { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public List<string> Technologies { get; set; } = [];
    public int Order { get; set; }
}
