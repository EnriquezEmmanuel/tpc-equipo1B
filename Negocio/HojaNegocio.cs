using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class HojaNegocio
    {
        public List<Hoja> lista()
        {
            List<Hoja> lista = new List<Hoja>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Tamaño, TipoPapel, Gramaje, Precio FROM Hoja");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Hoja aux = new Hoja();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tamaño = (string)datos.Lector["Tamaño"];
                    aux.TipoPapel = (string)datos.Lector["TipoPapel"];
                    aux.Gramaje = (string)datos.Lector["Gramaje"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex) 
            { throw ex; }
            finally { datos.cerrarConexion(); }

        }
        public List<string> listarTamaños()
        {
            List<string> lista = new List<string>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT DISTINCT Tamaño FROM Hoja");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                    lista.Add((string)datos.Lector["Tamaño"]);

                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }

        public List<string> listarTiposPapel()
        {
            List<string> lista = new List<string>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT DISTINCT TipoPapel FROM Hoja");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                    lista.Add((string)datos.Lector["TipoPapel"]);

                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }

        public List<string> listarGramajes()
        {
            List<string> lista = new List<string>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT DISTINCT Gramaje FROM Hoja");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                    lista.Add((string)datos.Lector["Gramaje"]);

                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }
        public decimal obtenerPrecio(string tamaño, string tipoPapel, string gramaje)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Precio FROM Hoja WHERE Tamaño = @tamaño AND TipoPapel = @tipoPapel AND Gramaje = @gramaje");
                datos.setearParametro("@tamaño", tamaño);
                datos.setearParametro("@tipoPapel", tipoPapel);
                datos.setearParametro("@gramaje", gramaje);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (decimal)datos.Lector["Precio"];

                return 0;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }
    }
}
