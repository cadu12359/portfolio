namespace Portfolio.Domain.Entities;

public class Education
{
    public int Id { get; set; }
    public string Institution { get; set; } = string.Empty;
    public string DegreePt { get; set; } = string.Empty;
    public string DegreeEn { get; set; } = string.Empty;
    public string Field { get; set; } = string.Empty;
    public int StartYear { get; set; }
    public int EndYear { get; set; }
}
