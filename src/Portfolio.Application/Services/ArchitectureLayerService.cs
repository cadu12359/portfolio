using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Domain.Interfaces;

namespace Portfolio.Application.Services;

public class ArchitectureLayerService(IArchitectureLayerRepository repository) : IArchitectureLayerService
{
    public async Task<IEnumerable<ArchitectureLayerDto>> GetAllOrderedAsync(string lang)
    {
        var layers = await repository.GetAllOrderedAsync();
        bool isPt = lang.StartsWith("pt", StringComparison.OrdinalIgnoreCase);

        return layers.Select(l => new ArchitectureLayerDto(
            l.Id,
            isPt ? l.NamePt : l.NameEn,
            isPt ? l.DescriptionPt : l.DescriptionEn,
            l.CodeSnippet,
            l.Language,
            l.GitHubFileUrl,
            l.Order
        ));
    }
}
