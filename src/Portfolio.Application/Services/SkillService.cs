using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Interfaces;

namespace Portfolio.Application.Services;

public class SkillService(ISkillRepository repository) : ISkillService
{
    public async Task<IEnumerable<SkillDto>> GetAllAsync(string lang)
    {
        var skills = await repository.GetAllAsync();
        bool isPt = lang.StartsWith("pt", StringComparison.OrdinalIgnoreCase);

        return skills
            .OrderBy(s => s.Order)
            .Select(s => new SkillDto(
                s.Id,
                isPt ? s.NamePt : s.NameEn,
                isPt ? s.CategoryPt : s.CategoryEn,
                s.Icon,
                s.Order
            ));
    }
}
