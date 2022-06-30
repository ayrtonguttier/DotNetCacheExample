using CacheExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace CacheExample.Controllers;

[ApiController]
public class CachedCepController : ControllerBase
{
    private readonly ICepService _service;

    public CachedCepController(ICepService service)
    {
        _service = service;
    }
    
    [HttpGet("/{cep}")]
    public async Task<IActionResult> ConsultarCep(string cep)
    {
        var endereco = await _service.GetEndereco(cep);
        return Ok(endereco);
    }
}