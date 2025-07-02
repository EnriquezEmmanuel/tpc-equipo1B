using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT id, Email, Pass, IdTipoUsuario AS TipoUsuario, IdUsuarioDatos AS UsuarioDatos FROM Usuario");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Pass = (string)datos.Lector["Pass"];
                    aux.TipoUsuario = (int)datos.Lector["TipoUsuario"];
                    aux.UsuarioDatos = (int)datos.Lector["UsuarioDatos"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public bool Loguear( string email, string pass)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IdTipoUsuario FROM Usuario WHERE Email=@Email AND Pass=@pass ");
                datos.setearParametro("@Email", email);
                datos.setearParametro("@pass", pass);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if(!(datos.Lector["IdTipoUsuario"] is DBNull))
                    return true; //se ejecuta primero y corta el while
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
