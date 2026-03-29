using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Interfaces;

namespace Portfolio.Application.Services;

public class ExperienceService(IExperienceRepository repository) : IExperienceService
{
    public async Task<IEnumerable<ExperienceDto>> GetAllAsync(string lang)
    {
        var experiences = await repository.GetAllAsync();
        bool isPt = lang.StartsWith("pt", StringComparison.OrdinalIgnoreCase);

        return experiences
            .OrderBy(e => e.Order)
            .Select(e => new ExperienceDto(
                e.Id,
                e.Company,
                isPt ? e.RolePt : e.RoleEn,
                isPt ? e.DescriptionPt : e.DescriptionEn,
                e.StartDate,
                e.EndDate,
                e.IsCurrent,
                e.Technologies,
                e.Order
            ));
    }
}
