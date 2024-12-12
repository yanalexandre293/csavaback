using System.ComponentModel.DataAnnotations.Schema;

[Table("Professor")]
public class Professor : Usuario
{
    public List<Disciplina> DisciplinasLecionadas { get; set; }
    public List<Turma> Turmas { get; set; }

    public Professor(int id, string nome, string email, string senha, List<Disciplina> disciplinasLecionadas, List<Turma> turmas)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Senha = senha;
        TipoUsuario = TipoUsuario.Professor;
        DisciplinasLecionadas = disciplinasLecionadas;
        Turmas = turmas;
    }

    public Professor()
    {
        Id = 0;
        Nome = "";
        Email = "";
        Senha = "";
        TipoUsuario = TipoUsuario.Estudante;
        DisciplinasLecionadas = [];
        Turmas = [];
    }

    
}