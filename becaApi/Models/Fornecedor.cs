using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace becaApi.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        public List<Produto> ProdutosOferecidos { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
    }
}
