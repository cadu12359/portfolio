using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces;
using Portfolio.Infrastructure.Data;

namespace Portfolio.Infrastructure.Repositories;

public class CertificationRepository(PortfolioDbContext context) : ICertificationRepository
{
    public async Task<IEnumerable<Certification>> GetAllAsync() =>
        await context.Certifications.OrderByDescending(c => c.IssueDate).ToListAsync();
}
