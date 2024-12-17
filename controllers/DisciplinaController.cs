using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("[controller]")]
public class DisciplinaController : ControllerBase
{
    public readonly DisciplinaRepository _disciplinaRepository;

    public DisciplinaController(DisciplinaRepository disciplinaRepository)
    {
        _disciplinaRepository = disciplinaRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarDisciplina(Disciplina disciplina)
    {
        await _disciplinaRepository.AdicionarDisciplina(disciplina);
        return Ok(disciplina);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Disciplina>> BuscarDisciplina(int id)
    {
        try
        {
            var disciplina = await _disciplinaRepository.BuscarDisciplina(id);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(disciplina, settings);

            return Content(json, "application/json");
        }catch(Exception error)
        {
            return NotFound(error);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Disciplina>>> BuscarTodasDisciplinas()
    {
        try
        {
            var disciplinas = await _disciplinaRepository.BuscarTodasDisciplinas();

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(disciplinas, settings);

            return Content(json, "application/json");
        }catch(Exception error)
        {
            return NotFound(error);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditarDisciplina(Disciplina disciplina)
    {
        try
        {
            await _disciplinaRepository.EditarDisciplina(disciplina);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest(error);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverDisciplina(int id)
    {
        try
        {
            await _disciplinaRepository.RemoverDisciplina(id);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest(error);
        }
    }
}