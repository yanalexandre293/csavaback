using Microsoft.EntityFrameworkCore;

public class AulaRepository
{
    private readonly AppDbContext _dbContext;

    public AulaRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AdicionarAula(Aula aula)
    {
        await _dbContext.Aulas.AddAsync(aula);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Aula>> BuscarTodasAulas()
    {
        return await _dbContext.Aulas.ToListAsync();
    }

    public async Task<Aula> BuscarAula(int id)
    {
        return await _dbContext.Aulas.FirstOrDefaultAsync(aula => aula.Id == id);
    }

    public async Task EditarAula(Aula aula)
    {
        var a = _dbContext.Aulas.FirstOrDefault(a => a.Id == aula.Id);
        a.Nome = aula.Nome;
        a.DisciplinaId = aula.DisciplinaId;
        a.Disciplina = aula.Disciplina;

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoverAula(int id)
    {
        var aula = await _dbContext.Aulas.FirstOrDefaultAsync(a => a.Id == id);
        _dbContext.Remove(aula);
        await _dbContext.SaveChangesAsync();
    }
}