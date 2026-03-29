using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Interfaces;

public interface IEducationRepository
{
    Task<IEnumerable<Education>> GetAllAsync();
}
