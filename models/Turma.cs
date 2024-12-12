using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Turma")]
public class Turma
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }

    public Turma(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public Turma()
    {
        Id = 0;
        Nome = "";
    }
}