using System.ComponentModel.DataAnnotations;

namespace escolaNc.Modelos
{
    public class Servico
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
    }
}
