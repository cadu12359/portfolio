using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using Portfolio.Infrastructure.Data;

namespace Portfolio.Infrastructure.Repositories;

public class ProjectRepository(PortfolioDbContext context) : IProjectRepository
{
    public async Task<IEnumerable<Project>> GetAllAsync() =>
        await context.Projects.OrderBy(p => p.Order).ToListAsync();
}
