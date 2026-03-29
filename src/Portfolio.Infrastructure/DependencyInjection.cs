using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Domain.Interfaces;
using Portfolio.Infrastructure.Data;
using Portfolio.Infrastructure.Repositories;

namespace Portfolio.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PortfolioDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IExperienceRepository, ExperienceRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ICertificationRepository, CertificationRepository>();
        services.AddScoped<IEducationRepository, EducationRepository>();
        services.AddScoped<IArchitectureLayerRepository, ArchitectureLayerRepository>();

        return services;
    }
}
