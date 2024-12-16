using Microsoft.EntityFrameworkCore;

public class ProfessorRepository
{
    private readonly AppDbContext _dbContext;

    public ProfessorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AdicionarProfessor(Professor professor)
    {
        await _dbContext.Professores.AddAsync(professor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Professor>> BuscarTodosProfessores()
    {
        return await _dbContext.Professores.Include(p => p.DisciplinasLecionadas).ToListAsync();
    }

    public async Task<Professor> BuscarProfessor(int id)
    {
        return await _dbContext.Professores.Include(p => p.DisciplinasLecionadas).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task EditarProfessor(Professor professor)
    {
        var prof = await _dbContext.Professores.Include(p => p.DisciplinasLecionadas).FirstOrDefaultAsync(p => p.Id == professor.Id);
        prof.Nome = professor.Nome;
        prof.Email = professor.Email;
        prof.Senha = professor.Senha;
        prof.TipoUsuario = professor.TipoUsuario;
        prof.DisciplinasLecionadas = professor.DisciplinasLecionadas;

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoverProfessor(int id)
    {
        _dbContext.Remove(await _dbContext.Professores.Include(p => p.DisciplinasLecionadas).FirstOrDefaultAsync(professor => professor.Id == id));
        await _dbContext.SaveChangesAsync();
    }
}