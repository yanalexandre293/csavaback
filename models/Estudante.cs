using System.ComponentModel.DataAnnotations.Schema;

[Table("Estudante")]
public class Estudante : Usuario
{
    public List<Disciplina>? DisciplinasCursadas { get; set; }
    public List<Aula>? AulasAssistidas { get; set; }
}