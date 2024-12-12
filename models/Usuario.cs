using System.ComponentModel.DataAnnotations;

public abstract class Usuario
{
    [Key]
    public int? Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public TipoUsuario TipoUsuario{ get; set; }
}