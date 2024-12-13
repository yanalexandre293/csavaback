using Microsoft.AspNetCore.Mvc;

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
    public async Task AdicionarAula(Aula aula)
    {
        
    }
}