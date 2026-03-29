using Portfolio.Application.DTOs;

namespace Portfolio.Application.Interfaces;

public interface IExperienceService
{
    Task<IEnumerable<ExperienceDto>> GetAllAsync(string lang);
}
