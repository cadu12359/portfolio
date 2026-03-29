using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Interfaces;

public interface IArchitectureLayerRepository
{
    Task<IEnumerable<ArchitectureLayer>> GetAllOrderedAsync();
}
