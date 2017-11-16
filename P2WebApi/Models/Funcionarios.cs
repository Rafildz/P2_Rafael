using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P2WebApi.Models
{
    public class Funcionarios
    {
        [Key]
        public Int32 IdFuncionario { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
    }
}