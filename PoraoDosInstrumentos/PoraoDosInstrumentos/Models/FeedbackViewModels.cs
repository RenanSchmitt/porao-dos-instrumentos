using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoraoDosInstrumentos.Models
{
    public class FeedbackViewModels
    {
        public string Comente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int? Select { get; set; }
        public List<Responda> Respondas { get; set; }
    }
}