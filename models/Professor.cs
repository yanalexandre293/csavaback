using System.ComponentModel.DataAnnotations.Schema;

public class Professor : Usuario
{
    public List<Disciplina>? DisciplinasLecionadas { get; set; }

    public Professor(string nome, string email, string senha)
    {
        this.Nome = nome;
        this.Email = email;
        this.Senha = senha;
        this.TipoUsuario = TipoUsuario.Professor;
    }

    protected Professor() { }
}