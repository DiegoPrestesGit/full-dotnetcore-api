using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace becaApi.Models
{
    public class PedidoProdutoRelation
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId {get;set;}
        public Produto Produto { get; set; }
    }
}
