using PoraoDosInstrumentos.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;


namespace PoraoDosInstrumentos.Models
{
   
    public class AnuncioInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AnuncioDBContext>
    {
        protected override void Seed(AnuncioDBContext context)
        {
            var categorias = new List<Categoria>
            {
                new Categoria { Nome = "Instrumento de cordas",
                    Descricao = "Nos instrumentos de cordas, o som é produzido pela vibração de uma corda, quando esta é friccionada ou percutida. Esta vibração é geralmente amplificada pois a maioria destes instrumentos apresenta uma caixa de ressonância. Exemplos deste tipo de instrumentos são o violino, a viola, a guitarra ou o contrabaixo. A qualidade sonora destes instrumentos depende da combinação entre as cordas utilizadas e a caixa de ressonância que na maioria das vezes é feita em madeira." },
                new Categoria { Nome = "Instrumentos de sopro",
                    Descricao = "Os instrumentos de sopro são usualmente constituídos por tubos e o som é produzido pelo movimento do ar que se encontra no seu interior. Os diferentes sons relacionam-se cpm o comprimento da coluna de ar movimentado. São exemplos de instrumentos de sopro, as flautas, o saxofone, o clarinete ou a trompa." },
                new Categoria { Nome = "Instrumentos de percussão",
                    Descricao = "Neste tipo de instrumentos, o som é produzido pela vibração de uma mambrana ou de uma superfídie. Esta oscilação pode ser provocada pela mão ou com a ajuda de baquetas, que podem ser de plástico ou de madeira. Exemplos deste tipo de instrumentos, são os tambores, as baterias, os xilofones ou os adufes." },

             };


            categorias.ForEach(s => context.Categorias.Add(s));
            context.SaveChanges();


			var vendedores = new List<Vendedor>
			{
				
				new Vendedor{
					
					
				
                Nome = "Admin",
				Endereco = "Rua Boticario",
                Telefone = "123456789",        
                Email = "admin@s2b.br",
                ImageUrl = ""

                },
                new Vendedor{



                Nome = "Consultor",
                Endereco = "Rua Boticario",
                Telefone = "123456789",
                Email = "hugo@s2b.br",
                ImageUrl = ""

                },
                 new Vendedor{



                Nome = "Consultor",
                Endereco = "Rua Boticario",
                Telefone = "123456789",
                Email = "ze@s2b.br",
                ImageUrl = ""

                },
                 new Vendedor{



                Nome = "Consultor",
                Endereco = "Rua Boticario",
                Telefone = "123456789",
                Email = "luis@s2b.br",
                ImageUrl = ""

                }




            };
			
			vendedores.ForEach(s => context.Vendedores.Add(s));
            context.SaveChanges();

            var locais = new List<Local>
            {

                   new Local { Nome = "Gravataí"},
                   new Local { Nome = "Porto Alegre" },
                   new Local { Nome = "Alvorada" },
                   new Local { Nome = "Canoas" },
                   new Local { Nome = "Viamão" }



            };



            locais.ForEach(s => context.Locais.Add(s));
            context.SaveChanges();


            var anuncios = new List<Anuncio> {

            new Anuncio {
                Titulo = "Guitarra Fender Stratocaster Standart Edition",
                Descricao = "Guitarra em estado de nova, regulada e com cordas novas.",
                Valor = 2500,
                ReleaseDate = DateTime.Parse("1/1/1989",new CultureInfo("en-US")),
                ImageUrl =  "",
                CategoriaID = categorias.Single( c => c.Nome == "Instrumento de cordas").CategoriaID,
                LocalID = locais.Single( c => c.Nome == "Gravataí").LocalID,
                VendedorID = vendedores.Single(c => c.Nome == "Admin").VendedorID,
                StatusItemID = 1

        },

                        new Anuncio {
                Titulo = "Flauta em Aço-Inoxidavel.",
                Descricao = "Flauta em estado de nova e regulada ",
                Valor = 5500,
                ReleaseDate = DateTime.Parse("1/1/1989",new CultureInfo("en-US")),
                ImageUrl =  "",
                CategoriaID = categorias.Single( c => c.Nome == "Instrumento de cordas").CategoriaID,
                LocalID = locais.Single( c => c.Nome == "Gravataí").LocalID,
                VendedorID = vendedores.Single(c => c.Nome == "Admin").VendedorID,
                StatusItemID = 1


        },
            new Anuncio {
                Titulo = "Bateria Pearl Completa com pratos",
                Descricao = "Bateria em estado de nova, peles trocadas e pratos novos.",
                Valor = 1500,
                ReleaseDate = DateTime.Parse("1/1/1989",new CultureInfo("en-US")),
                ImageUrl =  "",
                CategoriaID = categorias.Single( c => c.Nome == "Instrumento de cordas").CategoriaID,
                LocalID = locais.Single( c => c.Nome == "Gravataí").LocalID,
                VendedorID = vendedores.Single(c => c.Nome == "Admin").VendedorID,
                StatusItemID = 1


            },



        };
            anuncios.ForEach(s => context.Anuncios.Add(s));
            context.SaveChanges();
        }
    }
}