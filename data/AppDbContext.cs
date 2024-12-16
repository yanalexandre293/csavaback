using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Estudante> Estudantes { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Disciplina> Disciplinas{ get; set; }
    public DbSet<Aula> Aulas { get; set; }
    public DbSet<Admin> Admins { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração de mapeamento por tipo (TPT)
        modelBuilder.Entity<Admin>()
            .ToTable("Usuarios"); // Tabela específica para Admins

        modelBuilder.Entity<Professor>()
            .ToTable("Usuarios"); // Tabela específica para Professores

        modelBuilder.Entity<Estudante>()
            .ToTable("Usuarios"); // Tabela específica para Estudantes


            
        // Configuração da tabela "Aula"
        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(a => a.Id); // Chave primária
            entity.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(200); // Nome obrigatório com tamanho máximo

            entity.HasOne(a => a.Disciplina) // Relação com Disciplina
                .WithMany(d => d.Aulas)
                .HasForeignKey(a => a.DisciplinaId)
                .OnDelete(DeleteBehavior.Cascade); // Exclui as aulas se a disciplina for removida
        });

        // Configuração da tabela "Disciplina"
        modelBuilder.Entity<Disciplina>(entity =>
        {
            entity.HasKey(d => d.Id); // Chave primária
            entity.Property(d => d.Nome)
                .IsRequired()
                .HasMaxLength(150); // Nome obrigatório com tamanho máximo
        });

        // Configuração da tabela "Estudante"
        modelBuilder.Entity<Estudante>(entity =>
        {
            entity.HasMany(e => e.DisciplinasCursadas) // Relação muitos-para-muitos com Disciplina
                .WithMany(); // Configura a tabela intermediária automaticamente

            entity.HasMany(e => e.AulasAssistidas) // Relação muitos-para-muitos com Aula
                .WithMany();
        });

        // Configuração da tabela "Professor"
        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasMany(p => p.DisciplinasLecionadas) // Relação 1:N com Disciplina
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict); // Restrição para evitar exclusão em cascata
        });

        // Configuração da tabela "Usuario" (classe abstrata)
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(u => u.Id); // Chave primária
            entity.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(u => u.Senha)
                .IsRequired();

            entity.Property(u => u.TipoUsuario)
                .IsRequired(); // Tipo de usuário obrigatório
        });
        // Mapeia a hierarquia para uma única tabela
        modelBuilder.Entity<Usuario>()
            .ToTable("Usuarios") // Usa a mesma tabela para toda a hierarquia
            .HasDiscriminator<TipoUsuario>("TipoUsuario")
            .HasValue<Professor>(TipoUsuario.Professor)
            .HasValue<Estudante>(TipoUsuario.Estudante)
            .HasValue<Admin>(TipoUsuario.Admin);

        // Herança: Configuração para "Estudante" e "Professor" herdarem "Usuario"
        modelBuilder.Entity<Estudante>().HasBaseType<Usuario>();
        modelBuilder.Entity<Professor>().HasBaseType<Usuario>();
        modelBuilder.Entity<Admin>().HasBaseType<Usuario>();
    }
}