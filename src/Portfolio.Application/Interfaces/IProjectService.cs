using Portfolio.Application.DTOs;

namespace Portfolio.Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetAllAsync(string lang);
}
