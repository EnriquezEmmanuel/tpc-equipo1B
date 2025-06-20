using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Calidad
    {
        public int Id{get;set;}
        public string Color{get;set;}
        public string Caracteristica{get;set;}
        public float Porcentaje{get;set;} // Podría ser decimal
    }
}
