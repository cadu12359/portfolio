using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Interfaces;

public interface IExperienceRepository
{
    Task<IEnumerable<Experience>> GetAllAsync();
}
