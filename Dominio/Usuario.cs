using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email{ get; set; }
        public string Pass{ get; set; }
        //Las dos siguientes las dejo con los tipo de datos originales por ahora
        public int TipoUsuario{ get; set; }
        public int UsuarioDatos{ get; set; }
    }
}
