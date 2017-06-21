using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PoraoDosInstrumentos.Models
{
    public class Anuncio
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Seu produto deve ter um Titulo!")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Seu produto deve ter uma Descrição!")]
        public string Descricao { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Range(0, 500)]
        public decimal Valor { get; set; }
        public string usuario { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Upload image")]
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }
        [Display(Name = "Image link")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int LocalID { get; set; }
        public virtual Local Local { get; set; }
        public int VendedorID { get; set; }
        public virtual Vendedor Vendedor { get; set; }

        public int StatusItemID{ get; set; }
        public virtual StatusItem StatusItem { get; set; }
    }
}