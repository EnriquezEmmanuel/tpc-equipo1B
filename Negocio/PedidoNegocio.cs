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
        public List<Pedido> lista()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("SELECT P.IdPedido, P.Fecha, U.Email, '('+H.Tamaño +', '+ H.TipoPapel+')' as 'Hoja', CAST(H.Precio AS char) as ValorHoja, C.Color, C.Calidad, CAST(C.Porcentaje AS char) as ValorImpresión, P.CopiaPorHoja, CASE WHEN P.Margenes=1 THEN 'Si' ELSE 'No' END AS Margen, P.Copias, E.Descripcion as Estado FROM Pedido P JOIN Usuario U ON P.IdUsuario = U.Id JOIN Hoja H ON P.IdHoja = H.Id JOIN Calidad C ON P.IdCalidad = C.Id JOIN Estado E ON P.IdEstado = E.Id");
                //datos.setearConsulta("SELECT  P.IdPedido AS Id, H.Tamaño FROM Pedido P JOIN Hoja H ON P.IdHoja = H.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido();
                    aux.IdPedido = (int)datos.Lector["IdPedido"] ;
                    aux.Email = (string)datos.Lector["Email"];
                    ////aux.Tamaño = (string)datos.Lector["Tamaño"];
                    //aux.Calidad = (int)datos.Lector["IdCalidad"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Hoja = (string)datos.Lector["Hoja"];
                    //aux.ValorHoja = (decimal)datos.Lector["ValorHoja"];
                    aux.Color = (string)datos.Lector["Color"];
                    aux.Calidad = (string)datos.Lector["Calidad"];
                    //aux.ValorImpresion = (decimal)datos.Lector["ValorImpresión"];
                    aux.CopiaPorHoja = (int)datos.Lector["CopiaPorHoja"];
                    aux.Margenes = (string)datos.Lector["Margen"];
                    aux.Copias = (int)datos.Lector["Copias"];
                    aux.Estado = (string)datos.Lector["Estado"];


                    //aux.Id = (int)datos.Lector["Id"];
                    //aux.Codigo = (string)datos.Lector["Codigo"];

                    ////Info Marca
                    //aux.Marca = new Marca();
                    //aux.Marca.Descripcion = (string)datos.Lector["MarcaDescripcion"];

                    //Info Catagoria                    
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { datos.cerrarConexion(); }
        }
        public void ModificarEstado(int id, string estado)
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
    }
}
