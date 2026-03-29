using Portfolio.Application.DTOs;

namespace Portfolio.Application.Interfaces;

public interface IArchitectureLayerService
{
    Task<IEnumerable<ArchitectureLayerDto>> GetAllOrderedAsync(string lang);
}
