public class Professor : Usuario
{
    public Professor(string nome, string email, string senha)
    {
        this.Nome = nome;
        this.Email = email;
        this.Senha = senha;
        this.TipoUsuario = TipoUsuario.Professor;
    }

    protected Professor() { }
}