using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("[controller]")]
public class ProfessorController : ControllerBase
{
    private readonly ProfessorRepository _profressorRepository;

    public ProfessorController(ProfessorRepository profressorRepository)
    {
        _profressorRepository = profressorRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarProfessor(Professor profressor)
    {
        try
        {
            await _profressorRepository.AdicionarProfessor(profressor);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest(error);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Professor>> BuscarProfessor(int id)
    {
        try
        {
            var professor = await _profressorRepository.BuscarProfessor(id);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(professor, settings);

            return Content(json, "application/json");
        }catch(Exception error)
        {
            return NotFound(error);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Professor>>> BuscarTodosProfessores()
    {
        try
        {
            var professores = await _profressorRepository.BuscarTodosProfessores();

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(professores, settings);

            return Content(json, "application/json");
            
        }catch(Exception error)
        {
            return NotFound(error);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditarProfessor(Professor profressor)
    {
        try
        {
            await _profressorRepository.EditarProfessor(profressor);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest(error);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverProfessor(int id)
    {
        try
        {
            await _profressorRepository.RemoverProfessor(id);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest(error);
        }
    }
}