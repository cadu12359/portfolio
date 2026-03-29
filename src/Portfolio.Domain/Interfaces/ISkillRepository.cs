using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Interfaces;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetAllAsync();
}
