using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Disciplina")]
public class Disciplina
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string Nome { get; set; }
    public List<Aula>? Aulas { get; set; }

    public Disciplina(string nome)
    {
        this.Nome = nome;
        this.Aulas = new List<Aula>();
    }

    protected Disciplina() { }
}