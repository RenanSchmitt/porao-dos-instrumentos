using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PoraoDosInstrumentos.Models
{
    public class Vendedor
    {
        public int VendedorID { get; set; }
        [Display(Name="Image link")]
        [DataType(DataType.ImageUrl)]
        public String ImageUrl { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
}