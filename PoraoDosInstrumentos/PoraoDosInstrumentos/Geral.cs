using PoraoDosInstrumentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoraoDosInstrumentos
{
    public class Geral
    {
     
        public static List<Responda> GetRespostas()
        {
            List<Responda> list = new List<Responda>();
            list.Add(new Responda() { ID = 1, Name = "Excelente", Css = "check w3" });
            list.Add(new Responda() { ID = 2, Name = "Bom", Css = "check w3ls" });
            list.Add(new Responda() { ID = 3, Name = "Neutro", Css = "check wthree" });
            list.Add(new Responda() { ID = 4, Name = "Ruim", Css = "check w3_agileits" });
            return list;
        }
    }
}