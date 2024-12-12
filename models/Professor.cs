using System.ComponentModel.DataAnnotations.Schema;

[Table("Professor")]
public class Professor : Usuario
{
    public List<Disciplina>? DisciplinasLecionadas { get; set; }
}