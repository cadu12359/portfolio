using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using Portfolio.Infrastructure.Data;

namespace Portfolio.Infrastructure.Repositories;

public class ExperienceRepository(PortfolioDbContext context) : IExperienceRepository
{
    public async Task<IEnumerable<Experience>> GetAllAsync() =>
        await context.Experiences.OrderBy(e => e.Order).ToListAsync();
}
