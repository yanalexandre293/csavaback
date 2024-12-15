-- INSTALAÇÕES NECESSARIAS --

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.Tools.DotNet
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Sqlite


-- FLUXO --

1 - CRIAR MODELS ---

[Table("Model")]
public class Model
{
    [Key]
    public int Id { get; set; }

    public Model(int id)
    {
        this.Id = id;
    }

    public Model()
    {
        this.Id = 0;
    }
}


2 - CRIAR DbContext ---

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Model> Models{ get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
    }
}

2 - Criar Repository

using Microsoft.EntityFrameworkCore;

public class AulaRepository
{
    private readonly AppDbContext _dbContext;

    public AulaRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

}

3 - Criar Controllers 

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
}


