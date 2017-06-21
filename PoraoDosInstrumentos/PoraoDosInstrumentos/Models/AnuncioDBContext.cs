using PoraoDosInstrumentos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace PoraoDosInstrumentos.Models
{
    public class AnuncioDBContext : DbContext
    {
        public AnuncioDBContext() : base("AnuncioDbContext") { }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<FeedBack> Feedbacks { get; set; }
        public DbSet<Informacao> Informacoes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<StatusItem> StatusItems { get; set; }

    }
}