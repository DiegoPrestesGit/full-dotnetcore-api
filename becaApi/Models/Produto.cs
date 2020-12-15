using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace becaApi.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public ICollection<PedidoProdutoRelation> ProdutosPedidos { get; set; }
        public EstoqueProduto Estoque { get; set; }
        public string Nome { get; set; }
        public int Pontuacao { get; set; }
        public double Preco { get; set; }
    }
}
