using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace becaApi.Models
{
    public class EstoqueProduto
    {
        [Key]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
