using System.ComponentModel.DataAnnotations;

namespace escolaNc.Modelos
{
    public class Usuario
    {
        public string nome { get; set; }
        public int idade { get; set; }
        [Key]
        public string cpf { get; set; }
        public string rg { get; set; }
        public string data_nasc { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
    }
}
