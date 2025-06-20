using System.ComponentModel.DataAnnotations.Schema;

public class Usuario
{
    public int Id { get; set; }

    [Column("nombre_usuario")]
    public string NombreUsuario { get; set; }

    [Column("password_hashed")]
    public string PasswordHashed { get; set; }
}
