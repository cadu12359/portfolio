using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Interfaces;

public interface ICertificationRepository
{
    Task<IEnumerable<Certification>> GetAllAsync();
}
