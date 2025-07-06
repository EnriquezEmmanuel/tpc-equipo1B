using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Dominio;
using Negocio;

namespace WebImprenta.Paginas
{
    public partial class PageLossPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try{
                //string script = "alert('¡Evento ejecutado correctamente!');";
                //ClientScript.RegisterStartupScript(this.GetType(), "alerta", script, true);

                UsuarioNegocio uNegocio = new UsuarioNegocio();
                string nuevaClave = uNegocio.VerificarMail(tbxEmail.Text);
                if (nuevaClave != null)
                {
                    //Enviar mail....
                    MjeError("Se envió un mail con una contraseña temporal.");

                }
                else
                {
                    MjeError("Email o Clave incorrecta.");
                }
            }
            catch (Exception ex)
            { MjeError("Hubo un error en la carga de la página. Intentelo más tarde. Error:" + ex.ToString()); }
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