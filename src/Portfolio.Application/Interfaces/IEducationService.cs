using Portfolio.Application.DTOs;

namespace Portfolio.Application.Interfaces;

public interface IEducationService
{
    Task<IEnumerable<EducationDto>> GetAllAsync(string lang);
}
