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
        public string MetodoPagamento { get; set; }
        public int PedidoProdutoRelationId { get; set; }
        public double Valor { get; set; }
        public int PontosTotais { get; set; }
    }
}
