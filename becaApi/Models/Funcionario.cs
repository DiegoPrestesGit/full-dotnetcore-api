using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace becaApi.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(ErrorMessage = "Este campo deve ter entre 10 e 20 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(ErrorMessage = "Este campo deve ter entre 10 e 20 caracteres")]
        public string Funcao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, double.MaxValue, ErrorMessage = "Este campo deve ter entre 10 e 20 caracteres")]
        public double Salario { get; set; }
        public int Preco { get; set; }

    }
}
