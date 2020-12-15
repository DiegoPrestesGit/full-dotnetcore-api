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

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(ErrorMessage = "Este campo deve ter entre 10 e 20 caracteres")]
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public List<Produto> ProdutosFornecido { get; set; }
    }
}
