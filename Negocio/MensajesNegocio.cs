using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;
namespace Negocio
{
    public class MensajesNegocio
    {
        public List<Mensajes> listar()
        {
            List<Mensajes> lista = new List<Mensajes>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT M.Id, M.IdPedido, UD.Nombre, TU.Tipo AS TipoUsuario, M.Fecha, M.Mensaje FROM Mensajes M JOIN Usuario U ON M.IdUsuario = U.Id JOIN TipoUsuario TU ON U.IdTipoUsuario = TU.Id JOIN UsuarioDatos UD ON UD.IdUsuario= U.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mensajes aux = new Mensajes();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdPedido = (long)datos.Lector["IdPedido"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.TipoUsuario = (string)datos.Lector["TipoUsuario"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Mensaje = (string)datos.Lector["Mensaje"];

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
        public void EnviarMensaje(long idPedido, int idUsuario, string mensaje)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Mensajes(IdPedido, IdUsuario, Fecha, Mensaje) VALUES (@IdPedido, @IdUsuario, @Fecha, @Mensaje)");

                datos.setearParametro("@IdPedido", idPedido);
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.setearParametro("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                datos.setearParametro("@Mensaje", mensaje);
                //obtener fecha

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { datos.cerrarConexion(); }

        }
    }
}
