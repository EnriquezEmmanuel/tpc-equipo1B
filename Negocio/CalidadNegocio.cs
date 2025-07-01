using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;

namespace Negocio
{
    public class CalidadNegocio
    {
        public List<Calidad> lista()
        {
            List<Calidad> lista = new List<Calidad>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Color, Calidad, Porcentaje From Calidad");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Calidad aux = new Calidad();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Color = (string)datos.Lector["Color"];
                    aux.Tipo = (string)datos.Lector["Calidad"];
                    aux.Porcentaje = (decimal)datos.Lector["Porcentaje"];

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
        public decimal obtenerPorcentaje(string color, string calidad, bool dobleCara)
        {
            string tipo = calidad + (dobleCara ? ", doble cara" : ", una cara");

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Porcentaje FROM Calidad WHERE Color = @color AND Calidad = @calidad");
                datos.setearParametro("@color", color);
                datos.setearParametro("@calidad", tipo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (decimal)datos.Lector["Porcentaje"];
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }

    }
}
