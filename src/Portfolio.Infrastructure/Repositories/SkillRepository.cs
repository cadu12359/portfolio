using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using Portfolio.Infrastructure.Data;

namespace Portfolio.Infrastructure.Repositories;

public class SkillRepository(PortfolioDbContext context) : ISkillRepository
{
    public async Task<IEnumerable<Skill>> GetAllAsync() =>
        await context.Skills.OrderBy(s => s.Order).ToListAsync();
}
