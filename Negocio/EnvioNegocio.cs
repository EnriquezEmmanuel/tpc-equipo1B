using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EnvioNegocio
    {
        public List<Envio> listar()
        {
            List<Envio> listaEnvios = new List<Envio>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT E.IdEnvio, E.IDDireccion, E.FechaEnvio, ME.Nombre as Metodo, EEN.Estado FROM Envio E JOIN MetodoEnvio ME ON ME.IdMetodoEnvio = E.IdMetodoEnvio JOIN EstadoEnvio EEN ON EEN.IdEstadoEnvio = E.IdEstadoEnvio");
                datos.ejecutarLectura();

                DireccionNegocio dirNegocio = new DireccionNegocio();
                Direccion DireccionSeleccionada = new Direccion();

                while (datos.Lector.Read())
                {
                    Envio aux = new Envio();
                   
                    DireccionSeleccionada = dirNegocio.ListarDirecciones().Find(x => x.Id == (int)datos.Lector["IDDireccion"]);

                    aux.IdEnvio = (int)datos.Lector["IdEnvio"];
                    aux.Direccion = DireccionSeleccionada;
                    aux.Fecha = (DateTime)datos.Lector["FechaEnvio"];
                    aux.Metodo = (string)datos.Lector["Metodo"];
                    aux.Estado = (string)datos.Lector["Estado"];


                    listaEnvios.Add(aux);
                }
                return listaEnvios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
