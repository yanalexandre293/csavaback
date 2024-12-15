using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("[controller]")]
public class AulaController : ControllerBase
{
    private readonly AulaRepository _aulaRepository;

    public AulaController(AulaRepository aulaRepository)
    {
        _aulaRepository = aulaRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarAula(Aula aula)
    {
        try
        {
            await _aulaRepository.AdicionarAula(aula);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest(error);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Aula>> BuscarAula(int id)
    {
        try
        {
            var aula = await _aulaRepository.BuscarAula(id);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(aula, settings);

            return Content(json, "application/json");
        }catch(Exception error)
        {
            return NotFound(error);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aula>>> BuscarTodasAulas()
    {
        try
        {
            var aulas = await _aulaRepository.BuscarTodasAulas();
            
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(aulas, settings);

            return Content(json, "application/json");
        }catch(Exception error)
        {
            return NotFound(error);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditarAula(Aula aula)
    {
        try
        {
            await _aulaRepository.EditarAula(aula);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest($"{error}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverAula(int id)
    {
        try
        {
            await _aulaRepository.RemoverAula(id);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest(error);
        }
    }
}