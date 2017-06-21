using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoraoDosInstrumentos.Models
{
    public class Comentario
    {
        public int ID { get; set; }
        public Informacao Informacoes { get; set; }
        public string Assunto { get; set; }

        }

    }
