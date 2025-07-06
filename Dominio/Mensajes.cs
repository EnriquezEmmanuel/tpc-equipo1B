using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mensajes
    {
        public int Id { get; set; }
        public long IdPedido { get; set; }
        public string Nombre { get; set; }
        public string TipoUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
    }
}
