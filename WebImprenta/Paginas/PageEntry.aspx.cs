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
    public partial class PageEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{"¡¡Funciona el evento!!"}');", true);

            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                Usuario usuario = new Usuario(tbxUsuario.Text, tbxClave.Text, false);
                Usuario UsuarioCompleto = negocio.Loguear(usuario);


                if (UsuarioCompleto != null)
                {
                    Session["usuario"] = UsuarioCompleto;

                    if (UsuarioCompleto.TipoUsuario == TipoUsuario.ADMIN)
                        Response.Redirect("PageRecepcion.aspx", false);
                    else
                        Response.Redirect("../Default.aspx", false);
                }
                else
                {
                    MjeError("User o pass incorrectos");
                }

            }
            catch (Exception ex)
            {
                MjeError("Hubo un error, inténtelo más tarde. Error: "+ ex.Message);
            }
        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string patron = @"^[a-z0-9._-]+@[a-z0-9_-]+(\.[a-z]{2,})+$";
            bool esValido = Regex.IsMatch(tbxEmail.Text, patron, RegexOptions.IgnoreCase);

            if (esValido)
            {
                UsuarioNegocio uNegocio = new UsuarioNegocio();
                string clave = uNegocio.IngresarUsuarioNuevo(tbxEmail.Text);
                try
                {
                    if (clave != null)
                    {
                        string mensaje = "Hola " + tbxNombre.Text + ". Esta es tu nueva clave temporal: <strong>" + clave;
                        mensaje += "</strong>.<br>Recuerda cambiarla al ingresar.<br>Para Continuar con el registro dirijete al siguiente link:<br>";
                        mensaje += "<a href=\"https://localhost:44386/Paginas/PageEntry.aspx \">Continuar con el registro</a>";

                        ServicioEmail servicioEmail = new ServicioEmail();
                        servicioEmail.ArmarCorreo(tbxEmail.Text, "Termina tu registro", mensaje);
                        servicioEmail.EnviarMail();

                        MjeError("Se ha enviado la clave temporal a tu casillla de e-mail.");
                    }
                    else
                    {
                        MjeError("El Usuario ya existe.");
                    }
                }
                catch (Exception ex)
                { MjeError("Ocurrio un problema al intentar registrarse. Error: " + ex.Message); }
            }
            else
            {
                MjeError("Formato inválido de e-mail.");
            }
        }
        //////////////////////// Mensajes de error ///////////////////////////////////
        protected void MjeError(string mje)
        {
            limpiarModal();
            TextoModal.Text = mje;
        }
        protected void limpiarModal()
        {
            string script = "Id('ventana-modal').style = 'display:flex;';";
            ClientScript.RegisterStartupScript(this.GetType(), "alerta", script, true);
        }
        protected void DevolverModal()
        {
            string script = "Id('ventana-modal').style = 'display:none;';";
            ClientScript.RegisterStartupScript(this.GetType(), "devolver", script, true);
        }


    }
}