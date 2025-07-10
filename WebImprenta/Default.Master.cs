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
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario User = (Usuario)Session["Usuario"];
            if (User?.DatosUsuario?.Nombre != null)
            {
                lblNombrePerfil.Visible = true;
                lblNombrePerfil.Text = User.DatosUsuario.Nombre; 
            } //Si da null pedir datos básicos de la cuenta
            else {
                lblNombrePerfil.Visible = false;
            }
        }
        protected void Desloguear_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Default.aspx", false);
        }
    }
}