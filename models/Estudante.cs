using System.ComponentModel.DataAnnotations.Schema;

public class Estudante : Usuario
{
    public List<Disciplina>? DisciplinasCursadas { get; set; }
    public List<Aula>? AulasAssistidas { get; set; }

    public Estudante(string nome, string email, string senha)
    {
        this.Nome = nome;
        this.Email = email;
        this.Senha = senha;
        this.TipoUsuario = TipoUsuario.Estudante;
    }

    protected Estudante() { }
}