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
        return await _dbContext.Professores.ToListAsync();
    }

    public async Task<Professor> BuscarProfessor(int id)
    {
        return await _dbContext.Professores.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task EditarProfessor(Professor professor)
    {
        var prof = await _dbContext.Professores.FirstOrDefaultAsync(p => p.Id == professor.Id);
        prof.Nome = professor.Nome;
        prof.Email = professor.Email;
        prof.Senha = professor.Senha;
        prof.TipoUsuario = professor.TipoUsuario;

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoverProfessor(int id)
    {
        _dbContext.Remove(await _dbContext.Professores.FirstOrDefaultAsync(professor => professor.Id == id));
        await _dbContext.SaveChangesAsync();
    }
}