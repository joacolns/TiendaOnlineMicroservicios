namespace UsuariosService.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string PasswordHashed { get; set; }
    }
}
