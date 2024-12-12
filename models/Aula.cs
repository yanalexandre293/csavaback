using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Aula")]
public class Aula
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }

    public int DisciplinaId { get; set; }
    public Disciplina Disciplina{ get; set; }

    public Aula(string nome, int disciplinaId)
    {
        this.Id = 0;
        this.Nome = nome;
        this.DisciplinaId = disciplinaId;
    }

    public Aula()
    {
        this.Id = 0;
        this.Nome = "";
        this.DisciplinaId = 0;
        this.Disciplina = null;
    }
}