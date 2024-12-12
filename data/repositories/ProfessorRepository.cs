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
    }

    public async Task<List<Professor>> BuscarTodosProfessores()
    {
        return await _dbContext.Professores.ToListAsync();
    }

    public async Task<Professor> BuscarProfessor(int id)
    {
        return await _dbContext.Professores.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task EditarProfessor(Professor )
    {

    }
}