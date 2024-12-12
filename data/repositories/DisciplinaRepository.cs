using Microsoft.EntityFrameworkCore;

public class DisciplinaRepository 
{
    private readonly AppDbContext _dbContext;

    public DisciplinaRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AdicionarDisciplina(Disciplina disciplina)
    {
        await _dbContext.Disciplinas.AddAsync(disciplina);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Disciplina>> BuscarTodasDisciplinas()
    {
        return await _dbContext.Disciplinas.ToListAsync();
    }

    public async Task<Disciplina> BuscarDisciplina(int id)
    {
        return await _dbContext.Disciplinas.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task EditarDisciplina(Disciplina disciplina)
    {
        var disc = await _dbContext.Disciplinas.FirstOrDefaultAsync(d => d.Id == disciplina.Id);
        disc.Nome = disciplina.Nome;
        disc.Aulas = disciplina.Aulas;

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoverDisciplina(int id)
    {
        var disc = await _dbContext.Disciplinas.FirstOrDefaultAsync(d => d.Id == id);
        _dbContext.Remove(disc);
        await _dbContext.SaveChangesAsync();
    }
}