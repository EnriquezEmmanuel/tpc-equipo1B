using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NegocioMetodoEnvio
    {
        public List<MetodoEnvio> listar()
        {
            List<MetodoEnvio> listaMetodos = new List<MetodoEnvio>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IdMetodoEnvio, Nombre FROM MetodoEnvio");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    MetodoEnvio aux = new MetodoEnvio();
                    aux.IdEnvio = Convert.ToInt32(datos.Lector["IdMetodoEnvio"]);
                    aux.Metodo = (string)datos.Lector["Nombre"];
                    listaMetodos.Add(aux);
                }
                return listaMetodos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
