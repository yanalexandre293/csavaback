public class Admin : Usuario
{
    public Admin(string nome, string email, string senha)
    {
        this.Nome = nome;
        this.Email = email;
        this.Senha = senha;
        this.TipoUsuario = TipoUsuario.Admin;
    }

    protected Admin() { }
}