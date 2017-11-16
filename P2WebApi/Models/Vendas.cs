using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P2WebApi.Models
{
    public class Vendas
    {
        [Key]
        public Int32 IdVendas { get; set; }
        public String Tipo { get; set; }
        public String Descricao { get; set; }
    }
}