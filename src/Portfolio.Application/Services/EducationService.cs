using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Interfaces;

namespace Portfolio.Application.Services;

public class EducationService(IEducationRepository repository) : IEducationService
{
    public async Task<IEnumerable<EducationDto>> GetAllAsync(string lang)
    {
        var educations = await repository.GetAllAsync();
        bool isPt = lang.StartsWith("pt", StringComparison.OrdinalIgnoreCase);

        return educations
            .OrderByDescending(e => e.StartYear)
            .Select(e => new EducationDto(
                e.Id,
                e.Institution,
                isPt ? e.DegreePt : e.DegreeEn,
                e.Field,
                e.StartYear,
                e.EndYear
            ));
    }
}
