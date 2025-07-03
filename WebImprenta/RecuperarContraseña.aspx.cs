using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WebImprenta
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.Visible = false;
            lblMensaje.Text = "";
            lblMensaje.Visible = false;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            string email = txtEmailRecuperar.Text.Trim();
            string nuevaPass = txtContraseniaRecuperaro.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(nuevaPass))
            {
                lblError.Text = "Debes completar los campos obligatorios: Email y Nueva contraseña.";
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            UsuarioNegocio negocio = new UsuarioNegocio();
            int encontrado = negocio.validarEmail(email);
            if (encontrado > 0)
            {
                negocio.actualizarContraseñaPorEmail(email, nuevaPass);
                lblMensaje.Text = "Contraseña actualizada correctamente.";
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "El email ingresado no está registrado.";
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}