using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Envio
    {
        public int IdEnvio{ get; set; }
        public Direccion Direccion{ get; set; }
        public DateTime Fecha{ get; set; }
        public string Metodo{ get; set; }
        public string Estado { get; set; }
    }
}
