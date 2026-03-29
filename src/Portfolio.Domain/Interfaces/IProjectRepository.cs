using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync();
}
