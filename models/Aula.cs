using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Aula")]
public class Aula
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string Nome { get; set; }
    public int DisciplinaId { get; set; }
    public Disciplina? Disciplina{ get; set; }
    public string Link { get; set; }

    public Aula(string nome, int disciplinaId, string link)
    {
        this.Nome = nome;
        this.DisciplinaId = disciplinaId;
        this.Link = link;
    }

    protected Aula() { }
}