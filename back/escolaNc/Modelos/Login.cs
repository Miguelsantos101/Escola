using System.ComponentModel.DataAnnotations;

namespace escolaNc.Modelos
{
    public class Registro
    {
        public string nome { get; set; }
        [Key]
        public string cpf { get; set; }
        public string hash_senha { get; set; }
    }
    public class Login
    {
        [Key]
        public string cpf { get; set; }
        public string hash_senha { get; set; }
    }
}
