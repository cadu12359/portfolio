using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Interfaces;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController(ISkillService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string lang = "pt")
    {
        var data = await service.GetAllAsync(lang);
        return Ok(data);
    }
}
