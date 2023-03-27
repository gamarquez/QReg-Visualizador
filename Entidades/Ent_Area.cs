using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_Area
    { 
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Ent_Area(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public Ent_Area()
        {

        }
    }
}
