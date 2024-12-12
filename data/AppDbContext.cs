using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Estudante> Estudantes { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Turma> Turmas{ get; set; }
    public DbSet<Disciplina> Disciplinas{ get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
    }
}