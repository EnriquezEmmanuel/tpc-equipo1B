using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;

namespace Negocio
{
    
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
            {
                List<Usuario> listaUsuarios = new List<Usuario>();
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearConsulta("SELECT id, Email, Pass, TipoUsuario, IdUsuarioDatos FROM Usuario");
                    datos.ejecutarLectura();

                    DatosUsuarioNegocio udNegocio = new DatosUsuarioNegocio();
                    List<DatosUsuario> ListaDatosUsuario = new List<DatosUsuario>();
                    ListaDatosUsuario = udNegocio.Listar();

                    //List<Direccion> ListaDirecciones = new List<Direccion>();
                    DireccionNegocio dNegocio = new DireccionNegocio();
                    
                    while (datos.Lector.Read())
                    {
                        Usuario aux = new Usuario();

                        aux.Id = (int)datos.Lector["Id"];
                        aux.Email = (string)datos.Lector["Email"];
                        aux.Pass = (string)datos.Lector["Pass"];

                        int tipo = Convert.ToInt32(datos.Lector["TipoUsuario"]);
                        aux.TipoUsuario = tipo == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;

                        long IdDatosUsuario= (long)datos.Lector["IdUsuarioDatos"];
                        aux.DatosUsuario = ListaDatosUsuario.Find(x => x.Id == IdDatosUsuario);


                        aux.Direcciones = dNegocio.ListarDirecciones(aux.Id);

                    //aux.UsuarioDatos = (long)datos.Lector["UsuarioDatos"];

                    listaUsuarios.Add(aux);
                    }
                    return listaUsuarios;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally { datos.cerrarConexion(); }
            }
           
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

        protected string AlfanuericoRandom(int longitud)
        {
            const string Caracteres = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789";
            Random rnd = new Random();
            char[] resultado = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                resultado[i] = Caracteres[rnd.Next(Caracteres.Length)];
            }
            return new string(resultado);
        }
        public string VerificarMail(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id FROM Usuario WHERE Email=@Email");
                datos.setearParametro("@Email", email);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (!(datos.Lector["Id"] is DBNull))
                    {
                        int id = (int)datos.Lector["Id"];
                        string claveTemporal = AlfanuericoRandom(8);
                        datos2.setearConsulta("UPDATE Usuario SET Pass=@ClTemp WHERE Id=@Id");
                        datos2.setearParametro("@Id", id);
                        datos2.setearParametro("@ClTemp", claveTemporal);
                        datos2.ejecutarAccion();
                        return claveTemporal;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
                datos2.cerrarConexion();
            }
        }


    }
}
