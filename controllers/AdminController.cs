using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly AdminRepository _adminRepository;

    public AdminController(AdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarAdmin(Admin admin)
    {
        try
        {
            await _adminRepository.AdicionarAdmin(admin);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest(error);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Admin>> BuscarAdmin(int id)
    {
        try
        {
            var admin = await _adminRepository.BuscarAdmin(id);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(admin, settings);

            return Content(json, "application/json");
        }catch(Exception error)
        {
            return NotFound(error);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Admin>>> BuscarTodosAdmins()
    {
        try
        {
            var admins = await _adminRepository.BuscarTodosAdmins();
            
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(admins, settings);

            return Content(json, "application/json");
        }catch(Exception error)
        {
            return NotFound(error);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditarAdmin(Admin admin)
    {
        try
        {
            await _adminRepository.EditarAdmin(admin);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest($"{error}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverAdmin(int id)
    {
        try
        {
            await _adminRepository.RemoverAdmin(id);
            return Ok();
        }catch(Exception error)
        {
            return BadRequest(error);
        }
    }
}