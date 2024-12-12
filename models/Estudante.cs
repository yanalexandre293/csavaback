using System.ComponentModel.DataAnnotations.Schema;

[Table("Estudante")]
public class Estudante : Usuario
{
    public List<Disciplina> DisciplinasCursadas { get; set; }
    public Turma Turma { get; set; }

    public Estudante(int id, string nome, string email, string senha, List<Disciplina> disciplinas, Turma turma)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Senha = senha;
        TipoUsuario = TipoUsuario.Estudante;
        DisciplinasCursadas = disciplinas;
        Turma = turma;
    }

    public Estudante()
    {
        Id = 0;
        Nome = "";
        Email = "";
        Senha = "";
        TipoUsuario = TipoUsuario.Estudante;
        DisciplinasCursadas = [];
        Turma = null;
    }

    
}