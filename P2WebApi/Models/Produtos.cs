using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P2WebApi.Models
{
    public class Produtos
    {
        [Key]
        public Int32 IdProduto { get; set; }
        public Int32 Quantidade { get; set; }
        public float Preco { get; set; }
        public String Nome { get; set; }
        public String Tipo { get; set; }
        public String Descricao { get; set; }
    }
}