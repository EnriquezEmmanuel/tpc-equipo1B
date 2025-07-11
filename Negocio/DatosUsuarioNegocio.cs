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
        public List<DatosUsuario> Listar()
        {
            List<DatosUsuario> listaDatosUsuario = new List<DatosUsuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IdUsuarioDatos, Nombre, Apellido, DNI FROM UsuarioDatos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    DatosUsuario aux = new DatosUsuario();

                    aux.Id = (long)datos.Lector["IdUsuarioDatos"];
                    aux.Nombre = (string)datos.Lector["Nombre"]; 
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    if (!(datos.Lector["DNI"] is DBNull))
                        aux.Dni = (long)datos.Lector["DNI"];

                    listaDatosUsuario.Add(aux);

                }
                return listaDatosUsuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool insertarUsuarioDatos(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                // Insertar datos personales
                datos.setearConsulta("INSERT INTO UsuarioDatos (Nombre, Apellido, DNI) OUTPUT INSERTED.IdUsuarioDatos VALUES (@Nombre, @Apellido, @DNI)");
                datos.setearParametro("@Nombre", usuario.DatosUsuario.Nombre);
                datos.setearParametro("@Apellido", usuario.DatosUsuario.Apellido);
                datos.setearParametro("@DNI", usuario.DatosUsuario.Dni);
                long idUsuarioDatos = (long)datos.ejecutarAccionScalar();

                // Actualizar en Usuario
                datos2.setearConsulta("UPDATE Usuario SET IdUsuarioDatos = @IdDatos WHERE Id = @IdUsuario");
                datos2.setearParametro("@IdDatos", idUsuarioDatos);
                datos2.setearParametro("@IdUsuario", usuario.Id);
                datos2.ejecutarAccion();

                usuario.DatosUsuario.Id = idUsuarioDatos;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                datos.cerrarConexion();
                datos2.cerrarConexion();
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