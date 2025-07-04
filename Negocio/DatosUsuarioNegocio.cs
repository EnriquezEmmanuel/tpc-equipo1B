using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DatosUsuarioNegocio
    {
        public bool insertarUsuarioDatos(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarUsuarioDatos");
                datos.setearParametro("@Id", usuario.Id);
                datos.setearParametro("@Nombre", usuario.DatosUsuario.Nombre);
                datos.setearParametro("@Apellido", usuario.DatosUsuario.Apellido);
                datos.setearParametro("@DNI", usuario.DatosUsuario.Dni);
                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public DatosUsuario obtenerUsuarioDatos(int IdUser)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("obtenerUsuarioDatos");
                datos.setearParametro("@Id", IdUser);  // CORREGIDO: era @@IDCliente

                datos.ejecutarLectura();  // usar ejecutarLectura en lugar de ejecutarAccion

                if (datos.Lector.Read())
                {
                    DatosUsuario aux = new DatosUsuario();
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Apellido = datos.Lector["Apellido"].ToString();
                    aux.Dni = Convert.ToInt32(datos.Lector["DNI"]);

                    return aux;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void actualizarUsuarioDatos(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("actualizarUsuarioDatos");
                datos.setearParametro("@Id", usuario.Id);
                datos.setearParametro("@Nombre", usuario.DatosUsuario.Nombre);
                datos.setearParametro("@Apellido", usuario.DatosUsuario.Apellido);
                datos.setearParametro("@DNI", usuario.DatosUsuario.Dni);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

    }
}