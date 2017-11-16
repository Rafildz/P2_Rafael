using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P2WebApi.Models
{
    public class CustosDespesas
    {
        [Key]
        public Int32 IdCD { get; set; }
        public String Tipo { get; set; }
        public String Descricao { get; set; }
    }
}