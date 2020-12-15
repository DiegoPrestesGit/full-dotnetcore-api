using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace becaApi.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<PedidoProdutoRelation> ProdutosPedidos { get; set; }
        public int PontosTotais { get; set; }
    }
}
