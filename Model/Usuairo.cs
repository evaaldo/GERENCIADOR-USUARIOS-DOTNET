namespace SistemaUsuarios.Model
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}