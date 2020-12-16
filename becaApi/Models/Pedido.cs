using System.ComponentModel.DataAnnotations;

namespace becaApi.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string MetodoPagamento { get; set; }
        public double Valor { get; set; }
        public int PontosTotais { get; set; }
    }
}
