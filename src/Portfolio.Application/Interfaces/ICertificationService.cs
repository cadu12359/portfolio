using Portfolio.Application.DTOs;

namespace Portfolio.Application.Interfaces;

public interface ICertificationService
{
    Task<IEnumerable<CertificationDto>> GetAllAsync(string lang);
}
