using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using Portfolio.Infrastructure.Data;

namespace Portfolio.Infrastructure.Repositories;

public class ArchitectureLayerRepository(PortfolioDbContext context) : IArchitectureLayerRepository
{
    public async Task<IEnumerable<ArchitectureLayer>> GetAllOrderedAsync() =>
        await context.ArchitectureLayers.OrderBy(l => l.Order).ToListAsync();
}
