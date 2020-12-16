using System.ComponentModel.DataAnnotations;

namespace becaApi.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        public int PedidoId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
    }
}
