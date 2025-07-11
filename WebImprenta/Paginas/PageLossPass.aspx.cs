using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Dominio;
using Negocio;
using System.Text.RegularExpressions;


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

                string patron = @"^[a-z0-9._-]+@[a-z0-9_-]+(\.[a-z]{2,})+$";

                bool esValido = Regex.IsMatch(tbxEmail.Text, patron, RegexOptions.IgnoreCase);

                if (esValido)
                {
                    UsuarioNegocio uNegocio = new UsuarioNegocio();
                    string nuevaClave = uNegocio.ActualizarContraseña(tbxEmail.Text);
                    if (nuevaClave != null)
                    {
                        string mensaje = "Nueva clave temporal: <strong>"+ nuevaClave;
                        mensaje += "</strong>.<br>Recuerde cambiarla al ingresar.";
                        ServicioEmail servicioEmail = new ServicioEmail();
                        servicioEmail.ArmarCorreo(tbxEmail.Text, "Recuperacion de Clave", mensaje);
                        try
                        {
                            servicioEmail.EnviarMail();
                            MjeError("Se envió un mail con una contraseña temporal.");
                        }
                        catch (Exception ex)
                        {
                            MjeError("Ocurrio un error al intentar enviar el E-mail: "+ ex.Message);
                        }
                        

                    }
                    else
                    {
                        MjeError("Email no registrado.");
                    }
                }
                else
                {
                    MjeError("Formato inválido de e-mail.");
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