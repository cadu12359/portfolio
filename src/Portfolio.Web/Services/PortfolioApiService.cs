using System.Net.Http.Json;
using Portfolio.Web.Models;

namespace Portfolio.Web.Services;

public class PortfolioApiService(HttpClient http)
{
    public async Task<IEnumerable<ExperienceDto>> GetExperiencesAsync(string lang) =>
        await http.GetFromJsonAsync<IEnumerable<ExperienceDto>>($"api/experiences?lang={lang}") ?? [];

    public async Task<IEnumerable<SkillDto>> GetSkillsAsync(string lang) =>
        await http.GetFromJsonAsync<IEnumerable<SkillDto>>($"api/skills?lang={lang}") ?? [];

    public async Task<IEnumerable<ProjectDto>> GetProjectsAsync(string lang) =>
        await http.GetFromJsonAsync<IEnumerable<ProjectDto>>($"api/projects?lang={lang}") ?? [];

    public async Task<IEnumerable<CertificationDto>> GetCertificationsAsync(string lang) =>
        await http.GetFromJsonAsync<IEnumerable<CertificationDto>>($"api/certifications?lang={lang}") ?? [];

    public async Task<IEnumerable<EducationDto>> GetEducationAsync(string lang) =>
        await http.GetFromJsonAsync<IEnumerable<EducationDto>>($"api/education?lang={lang}") ?? [];

    public async Task<IEnumerable<ArchitectureLayerDto>> GetArchitectureAsync(string lang) =>
        await http.GetFromJsonAsync<IEnumerable<ArchitectureLayerDto>>($"api/architecture?lang={lang}") ?? [];
}
