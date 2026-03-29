using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Interfaces;

namespace Portfolio.Application.Services;

public class ProjectService(IProjectRepository repository) : IProjectService
{
    public async Task<IEnumerable<ProjectDto>> GetAllAsync(string lang)
    {
        var projects = await repository.GetAllAsync();
        bool isPt = lang.StartsWith("pt", StringComparison.OrdinalIgnoreCase);

        return projects
            .OrderBy(p => p.Order)
            .Select(p => new ProjectDto(
                p.Id,
                isPt ? p.TitlePt : p.TitleEn,
                isPt ? p.DescriptionPt : p.DescriptionEn,
                p.Technologies,
                p.GitHubUrl,
                p.LiveUrl,
                p.Order
            ));
    }
}
