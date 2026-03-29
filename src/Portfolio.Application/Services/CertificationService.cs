using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Interfaces;

namespace Portfolio.Application.Services;

public class CertificationService(ICertificationRepository repository) : ICertificationService
{
    public async Task<IEnumerable<CertificationDto>> GetAllAsync(string lang)
    {
        var certs = await repository.GetAllAsync();
        bool isPt = lang.StartsWith("pt", StringComparison.OrdinalIgnoreCase);

        return certs
            .OrderByDescending(c => c.IssueDate)
            .Select(c => new CertificationDto(
                c.Id,
                isPt ? c.NamePt : c.NameEn,
                c.Issuer,
                c.IssueDate,
                c.CredentialUrl
            ));
    }
}
