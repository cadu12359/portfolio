using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Interfaces;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArchitectureController(IArchitectureLayerService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string lang = "pt")
    {
        var data = await service.GetAllOrderedAsync(lang);
        return Ok(data);
    }
}
