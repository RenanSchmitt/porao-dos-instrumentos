using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoraoDosInstrumentos.Models
{
    public class Informacao
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

    }
}