using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Dominio;

namespace WebImprenta.Paginas
{
    public partial class PageRegistry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
                return;
            }
            else
            {
                if (!IsPostBack)
                {
                    var advertencia = Session["Advertencia"] as string;
                    if (!string.IsNullOrEmpty(advertencia))
                    {
                        MjeError(advertencia);
                    }
                }
                Usuario User = (Usuario)Session["Usuario"];
            }
        }
        protected void MjeError(string mje)
        {
            limpiarModal();
            TextoModal.Text = mje;
        }
        protected void limpiarModal()
        {
            string script = "Id('ventana-modal').style = 'display:flex;';";
            ClientScript.RegisterStartupScript(this.GetType(), "alerta", script, true);
            //btnAceptarModal.Style["display"] = "none";
        }
        protected void DevolverModal()
        {
            string script = "Id('ventana-modal').style = 'display:none;';";
            ClientScript.RegisterStartupScript(this.GetType(), "devolver", script, true);
            //btnAceptarModal.Style["display"] = "flex";
        }
    }
}