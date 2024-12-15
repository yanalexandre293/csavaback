using Microsoft.EntityFrameworkCore;

public class EstudanteRepository
{
    private readonly AppDbContext _dbContext;

    public EstudanteRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AdicionarEstudante(Estudante estudante)
    {
        await _dbContext.Estudantes.AddAsync(estudante);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Estudante>> BuscarTodosEstudantes()
    {
        return await _dbContext.Estudantes.Include(e => e.AulasAssistidas).Include(e => e.DisciplinasCursadas).ToListAsync();
    }

    public async Task<Estudante> BuscarEstudante(int id)
    {
        return await _dbContext.Estudantes.Include(e => e.AulasAssistidas).Include(e => e.DisciplinasCursadas).FirstOrDefaultAsync(estudante => estudante.Id == id);
    }

    public async Task EditarEstudante(Estudante estudante)
    {
        var est = await _dbContext.Estudantes.Include(e => e.AulasAssistidas).Include(e => e.DisciplinasCursadas).FirstOrDefaultAsync(est => est.Id == estudante.Id);
        est.Nome = estudante.Nome;
        est.Email = estudante.Email;
        est.Senha = estudante.Senha;
        est.TipoUsuario = estudante.TipoUsuario;
        est.DisciplinasCursadas = estudante.DisciplinasCursadas;
        est.AulasAssistidas = estudante.AulasAssistidas;

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoverEstudante(int id)
    {
        var estudante = await _dbContext.Estudantes.Include(e => e.AulasAssistidas).Include(e => e.DisciplinasCursadas).FirstOrDefaultAsync(estudante => estudante.Id == id);
        _dbContext.Remove(estudante);
        await _dbContext.SaveChangesAsync();
    }
}