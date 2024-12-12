using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Disciplina")]
public class Disciplina
{
    [Key]
    public int? Id { get; set; }
    public string Nome { get; set; }
    public List<Aula>? Aulas { get; set; }
}