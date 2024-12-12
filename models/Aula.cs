using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Aula")]
public class Aula
{
    [Key]
    public int? Id { get; set; }
    public string Nome { get; set; }
    public int DisciplinaId { get; set; }
    public Disciplina? Disciplina{ get; set; }
}