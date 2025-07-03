using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2
    }
    public class Usuario
    {
        public int Id { get; set; }

        public DatosUsuario DatosUsuario { get; set; } = new DatosUsuario();
        public List<Direccion> Direcciones { get; set; } = new List<Direccion>();
        public string Email { get; set; }
        public string Pass { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Usuario(string email, string pass, bool admin)
        {

            Email = email;
            Pass = pass;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }

        public Usuario(string nombre, string apellido, int dni)
        {
            DatosUsuario = new DatosUsuario
            {
                Nombre = nombre,
                Apellido = apellido,
                Dni = dni
            };
        }
        public Usuario() { }

    }
}

