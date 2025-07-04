using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;

namespace Negocio
{
    //public class UsuarioNegocio
    //{
    //        public List<Usuario> listar()
    //        {
    //            List<Usuario> lista = new List<Usuario>();
    //            AccesoDatos datos = new AccesoDatos();
    //            try
    //            {
    //                datos.setearConsulta("SELECT id, Email, Pass, IdTipoUsuario AS TipoUsuario, IdUsuarioDatos AS UsuarioDatos FROM Usuario");
    //                datos.ejecutarLectura();

    //                while (datos.Lector.Read())
    //                {
    //                    Usuario aux = new Usuario();

    //                    aux.Id = (int)datos.Lector["Id"];
    //                    aux.Email = (string)datos.Lector["Email"];
    //                    aux.Pass = (string)datos.Lector["Pass"];
    //                    aux.TipoUsuario = (int)datos.Lector["TipoUsuario"];
    //                    aux.UsuarioDatos = (int)datos.Lector["UsuarioDatos"];

    //                    lista.Add(aux);
    //                }
    //                return lista;
    //            }
    //            catch (Exception ex)
    //            {
    //                throw ex;
    //            }
    //            finally { datos.cerrarConexion(); }
    //        }
    //        public bool Loguear( string email, string pass)
    //        {
    //            AccesoDatos datos = new AccesoDatos();
    //            try
    //            {
    //                datos.setearConsulta("SELECT IdTipoUsuario FROM Usuario WHERE Email=@Email AND Pass=@pass ");
    //                datos.setearParametro("@Email", email);
    //                datos.setearParametro("@pass", pass);

    //                datos.ejecutarLectura();

    //                while (datos.Lector.Read())
    //                {
    //                    if(!(datos.Lector["IdTipoUsuario"] is DBNull))
    //                    return true; //se ejecuta primero y corta el while
    //                }
    //                return false;
    //            }
    //            catch (Exception ex)
    //            {
    //                throw ex;
    //            }
    //            finally { datos.cerrarConexion(); }
    //        }
    //    }
    //}

    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, TipoUsuario from Usuario where Email = @Email AND Pass = @Pass");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Pass", usuario.Pass);

                datos.ejecutarLectura();



                while (datos.Lector.Read())
                {
                    usuario.Id = Convert.ToInt32(datos.Lector["Id"]);
                    int tipo = Convert.ToInt32(datos.Lector["TipoUsuario"]);
                    usuario.TipoUsuario = tipo == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    return true;
                }

                return false;
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

        public int insertarNuevo(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Pass", usuario.Pass);
                datos.setearParametro("@TipoUsuario", usuario.TipoUsuario);
                return datos.ejecutarAccionScalar();

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
        public int validarEmail(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ValidarEmail");
                datos.setearParametro("@Email", email);
                int resultado = (int)datos.ejecutarAccionScalar();
                return resultado;


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

        public void actualizarContraseñaPorEmail(string email, string nuevaPass)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("recuperarContra");
                datos.setearParametro("@Email", email);
                datos.setearParametro("@Pass", nuevaPass);
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
