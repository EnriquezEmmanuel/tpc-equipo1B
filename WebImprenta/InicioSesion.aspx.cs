using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebImprenta
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx", false);
        }
        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                Usuario usuario = new Usuario(txtCorreo.Text, txtContrasenia.Text, false);
                Usuario UsuarioCompleto = negocio.Loguear(usuario);


                if (UsuarioCompleto != null)
                {
                    Session["usuario"] = UsuarioCompleto;

                    if (UsuarioCompleto.TipoUsuario == TipoUsuario.ADMIN)
                        Response.Redirect("~/Paginas/PageRecepcion.aspx", false);
                    else
                        Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void BtnRecuperarContraseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("Paginas/PageLossPass.aspx", false);
        }
    }
}