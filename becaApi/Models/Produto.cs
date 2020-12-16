using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace becaApi.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        public int PedidoProdutoRelationId { get; set; }
        public int EstoqueId { get; set; }
        public string Nome { get; set; }
        public int Pontuacao { get; set; }
        public double Preco { get; set; }
    }
}
