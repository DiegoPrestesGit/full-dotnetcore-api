using System.ComponentModel.DataAnnotations;

namespace becaApi.Models
{
    public class PedidoProdutoRelation
    {
        [Key]
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId {get;set;}
    }
}
