using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PoraoDosInstrumentos.Models
{
    public class FeedBack
    {
        public int ID { get; set; }
        public int? Responda { get; set; }
        [StringLength(200)]
        public string Comente { get; set; }
        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(125)]
        public string Email { get; set; }

    }
}