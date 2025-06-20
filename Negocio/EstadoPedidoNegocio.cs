using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;

namespace Negocio
{
    public class EstadoPedidoNegocio
    {
        public List<EstadoPedido> lista()
        {
            List<EstadoPedido> lista = new List<EstadoPedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM Estado");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    EstadoPedido aux = new EstadoPedido();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception){ throw; }
            finally { datos.cerrarConexion(); }
            
        }
    }
}
