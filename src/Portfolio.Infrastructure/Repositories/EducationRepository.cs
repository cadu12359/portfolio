using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using Portfolio.Infrastructure.Data;

namespace Portfolio.Infrastructure.Repositories;

public class EducationRepository(PortfolioDbContext context) : IEducationRepository
{
    public async Task<IEnumerable<Education>> GetAllAsync() =>
        await context.Educations.OrderByDescending(e => e.StartYear).ToListAsync();
}
