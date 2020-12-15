using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace becaApi.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo tem no maximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, double.MaxValue, ErrorMessage = "caracteres demais!")]
        public double Pontuacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, double.MaxValue, ErrorMessage = "caracteres demais!")]
        public double Preco { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
    }
}
