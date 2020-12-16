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
        public string CNPJ { get; set; }
        public string Nome { get; set; }
    }
}
