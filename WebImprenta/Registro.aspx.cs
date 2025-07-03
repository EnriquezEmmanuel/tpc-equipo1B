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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Email = txtEmailRegistro.Text;
                string Pass = txtContraseniaRegistro.Text;
                Usuario usuario = (Usuario)Session["usuario"];
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                if (usuarioNegocio.validarEmail(Email) == 1)
                {
                    Session.Add("error", "El correo ya fue registrado");
                    Response.Redirect("Error.aspx", false);
                }
                else
                {

                    Usuario user = new Usuario(Email, Pass, false);
                    //UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    int id = usuarioNegocio.insertarNuevo(user);

                    if (id != 0)
                    {

                        Response.Redirect("InicioSesion.aspx");
                    }
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}