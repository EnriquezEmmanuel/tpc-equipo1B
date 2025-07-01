using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Serializable] //Para poder pasarlo por partes
    public class Pedido
    {

        public int IdPedido { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public DateTime Fecha { get; set; }
        public int IdHoja { get; set; }
        public int IdCalidad { get; set; }
        public int CopiaPorHoja { get; set; }
        public bool Margenes { get; set; }
        public int Copias { get; set; }
        public string Estado { get; set; }

    }
}
