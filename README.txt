-- INSTALAÇÕES NECESSARIAS --

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.Tools.DotNet
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef

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