using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;

namespace Negocio
{
    public class PedidoNegocio
    {
        public List<Hoja> ListaHojas { get; set; }
        public List<Calidad> ListaCalidad { get; set; }
        public List<Pedido> lista()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("SELECT P.IdPedido, UD.Nombre, U.Email, P.Fecha, P.IdHoja, P.IdCalidad, P.CopiaPorHoja, P.Margenes, P.Copias, E.Descripcion AS Estado, F.Precio AS PrecioPedido FROM Pedido P JOIN Usuario U ON P.IdUsuario = U.Id JOIN EstadoPedido E ON P.IdEstado = E.Id JOIN UsuarioDatos UD ON U.IdUsuarioDatos = UD.IdUsuarioDatos JOIN Factura F ON F.IdPedido=P.IdPedido");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();

                    aux.IdPedido = (long)datos.Lector["IdPedido"];
                    aux.NombreUsuario = (string)datos.Lector["Nombre"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];

                    HojaNegocio hNegocio = new HojaNegocio();
                    ListaHojas = hNegocio.lista();
                    aux.Hoja = new Hoja();
                    aux.Hoja = ListaHojas.Find(x => x.Id == (int)datos.Lector["IdHoja"]);

                    CalidadNegocio cNegocio = new CalidadNegocio();
                    ListaCalidad = cNegocio.lista();
                    aux.Calidad = new Calidad();
                    aux.Calidad = ListaCalidad.Find(x => x.Id == (int)datos.Lector["IdCalidad"]);

                    aux.CopiaPorHoja = (int)datos.Lector["CopiaPorHoja"];
                    aux.Margenes = (bool)datos.Lector["Margenes"];
                    aux.Copias = (int)datos.Lector["Copias"];

                    aux.Estado = (string)datos.Lector["Estado"];// ahora lo corrijo
                    aux.PrecioPedido = (decimal)datos.Lector["PrecioPedido"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { datos.cerrarConexion(); }
        }
        public void ModificarEstado(long id, string estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Pedido SET IdEstado = (SELECT Id FROM Estado WHERE Descripcion = @estado) WHERE IdPedido = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@estado", estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { datos.cerrarConexion(); }

        }
        public List<Pedido> BuscarPedidos(string Email)
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("SELECT P.IdPedido, UD.Nombre, U.Email, P.Fecha, P.IdHoja, P.IdCalidad, P.CopiaPorHoja, P.Margenes, P.Copias, E.Descripcion AS Estado FROM Pedido P JOIN Usuario U ON P.IdUsuario = U.Id JOIN EstadoPedido E ON P.IdEstado = E.Id JOIN UsuarioDatos UD ON U.IdUsuarioDatos = UD.IdUsuarioDatos WHERE U.Email=@Email");
                datos.setearParametro("@Email", Email);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();

                    aux.IdPedido = (long)datos.Lector["IdPedido"];
                    aux.NombreUsuario = (string)datos.Lector["Nombre"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];

                    HojaNegocio hNegocio = new HojaNegocio();
                    ListaHojas = hNegocio.lista();
                    aux.Hoja = new Hoja();
                    aux.Hoja = ListaHojas.Find(x => x.Id == (int)datos.Lector["IdHoja"]);

                    CalidadNegocio cNegocio = new CalidadNegocio();
                    ListaCalidad = cNegocio.lista();
                    aux.Calidad = new Calidad();
                    aux.Calidad = ListaCalidad.Find(x => x.Id == (int)datos.Lector["IdCalidad"]);

                    aux.CopiaPorHoja = (int)datos.Lector["CopiaPorHoja"];
                    aux.Margenes = (bool)datos.Lector["Margenes"];
                    aux.Copias = (int)datos.Lector["Copias"];

                    aux.Estado = (string)datos.Lector["Estado"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { datos.cerrarConexion(); }
        }
    }
}
