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
        return await _dbContext.Aulas.Include(a => a.Disciplina).ToListAsync();
    }

    public async Task<Aula> BuscarAula(int id)
    {
        return await _dbContext.Aulas.Include(a => a.Disciplina).FirstOrDefaultAsync(aula => aula.Id == id);
    }

    public async Task EditarAula(Aula aula)
    {
        var a = await _dbContext.Aulas.FirstOrDefaultAsync(a => a.Id == aula.Id);

        if (a == null)
        {
            throw new KeyNotFoundException("Aula não encontrada.");
        }
        a.Nome = aula.Nome;
        a.DisciplinaId = aula.DisciplinaId;
        
        var disciplina = await _dbContext.Disciplinas.FirstOrDefaultAsync(d => d.Id == aula.DisciplinaId);

        a.Disciplina = disciplina;

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoverAula(int id)
    {
        var aula = await _dbContext.Aulas.Include(a => a.Disciplina).FirstOrDefaultAsync(a => a.Id == id);
        _dbContext.Remove(aula);
        await _dbContext.SaveChangesAsync();
    }
}