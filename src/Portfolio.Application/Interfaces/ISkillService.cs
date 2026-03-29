using Portfolio.Application.DTOs;

namespace Portfolio.Application.Interfaces;

public interface ISkillService
{
    Task<IEnumerable<SkillDto>> GetAllAsync(string lang);
}
