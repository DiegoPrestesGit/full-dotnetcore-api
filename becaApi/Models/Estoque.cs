using System.ComponentModel.DataAnnotations;

namespace becaApi.Models
{
    public class Estoque
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
    }
}
