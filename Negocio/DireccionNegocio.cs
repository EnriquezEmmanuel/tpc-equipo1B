using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DireccionNegocio
    {
        public void InsertarDireccion(int IdUser, Direccion direccion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("InsertarDireccion");
                datos.setearParametro("@Id", IdUser);
                datos.setearParametro("@Direccion", direccion.Calle);
                datos.setearParametro("@Altura", direccion.Altura);
                datos.setearParametro("@Departamento", direccion.Departamento);
                datos.setearParametro("@Piso", direccion.Piso);
                datos.setearParametro("@CodPostal", direccion.CodPostal);
                datos.setearParametro("@Ciudad", direccion.Ciudad);
                datos.ejecutarAccion(); // método que ejecuta el SP sin esperar resultados
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

        public List<Direccion> ListarDirecciones(int IdUser)
        {
            List<Direccion> lista = new List<Direccion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("FiltrarDireccionPorUsuario");
                datos.setearParametro("@Id", IdUser);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Direccion aux = new Direccion();
                    aux.Id = Convert.ToInt32(datos.Lector["IDDireccion"]);
                    aux.Calle = datos.Lector["Direccion"].ToString();
                    aux.Altura = datos.Lector["Altura"].ToString();
                    aux.Departamento = datos.Lector["Departamento"].ToString();
                    aux.Piso = datos.Lector["Piso"].ToString();
                    aux.CodPostal = datos.Lector["CodPostal"] != DBNull.Value ? Convert.ToInt32(datos.Lector["CodPostal"]) : 0;
                    aux.Ciudad = datos.Lector["Ciudad"].ToString();
                    aux.Activo = Convert.ToBoolean(datos.Lector["Activo"]);

                    lista.Add(aux);
                }

                return lista;
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

        public void EliminarDireccion(int idDireccion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("EliminarDireccionPorId");
                datos.setearParametro("@Id", idDireccion);
                datos.ejecutarAccion();
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


    }
}
