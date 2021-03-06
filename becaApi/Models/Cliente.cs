﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace becaApi.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        public string Phone { get; set; }
        public int Pontos { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public bool FlagDesconto { get; set; }
    }
}
