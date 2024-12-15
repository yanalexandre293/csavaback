using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("[controller]")]
public class EstudanteController : ControllerBase
{
    private readonly EstudanteRepository _estudanteRepository;

    public EstudanteController(EstudanteRepository estudanteRepository)
    {
        _estudanteRepository = estudanteRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarEstudante(Estudante estudante)
    {
        try
        {
            await _estudanteRepository.AdicionarEstudante(estudante);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest(error);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Estudante>> BuscarEstudante(int id)
    {
        try
        {
            var estudante = await _estudanteRepository.BuscarEstudante(id);
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(estudante, settings);

            return Content(json, "application/json");
        }catch(Exception error)
        {
            return NotFound(error);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Estudante>>> BuscarTodosEstudantes()
    {
        try
        {
            var estudantes = await _estudanteRepository.BuscarTodosEstudantes();

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(estudantes, settings);

            return Content(json, "application/json");
        }catch(Exception error)
        {
            return NotFound(error);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditarEstudante(Estudante estudante)
    {
        try
        {
            await _estudanteRepository.EditarEstudante(estudante);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest(error);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverEstudante(int id)
    {
        try
        {
            await _estudanteRepository.RemoverEstudante(id);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest(error);
        }
    }
}