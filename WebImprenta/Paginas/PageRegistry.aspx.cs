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
    public partial class PageRegistry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDto.Attributes.Add("autocomplete", "off");
            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                txtEmail.Text = usuario.Email;

                // Cargar direcciones
                DireccionNegocio dNeg = new DireccionNegocio();
                usuario.Direcciones = dNeg.ListarDirecciones(usuario.Id);
                Session["usuario"] = usuario;

                rptDirecciones.DataSource = usuario.Direcciones;
                rptDirecciones.DataBind();
                
            }
            txtDto.Text = "";
        }

        protected void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];

            // Validación básica de campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                !int.TryParse(txtDni.Text, out int dni) || dni <= 0)
            {
                MjeError("Debe completar Nombre, Apellido y un DNI válido.");
                return;
            }

            // Crear objeto DatosUsuario si es null
            if (usuario.DatosUsuario == null)
                usuario.DatosUsuario = new DatosUsuario();

            usuario.DatosUsuario.Nombre = txtNombre.Text.Trim();
            usuario.DatosUsuario.Apellido = txtApellido.Text.Trim();
            usuario.DatosUsuario.Dni = dni;

            // Guardar en la base de datos
            DatosUsuarioNegocio datosNeg = new DatosUsuarioNegocio();
            var datosExistentes = datosNeg.obtenerUsuarioDatos(usuario.Id);

            bool operacionExitosa;

            if (datosExistentes == null)
            {
                operacionExitosa = datosNeg.insertarUsuarioDatos(usuario);
            }
            else
            {
                datosNeg.actualizarUsuarioDatos(usuario);
                operacionExitosa = true;
            }

            // Refrescar la sesión con datos actualizados
            Session["usuario"] = usuario;

            if (operacionExitosa)
                MjeError("Datos actualizados correctamente.");
            else
                MjeError("Ocurrió un error al actualizar los datos.");
        }

        protected void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];

            // Validar que usuario.DatosUsuario exista antes de agregar dirección
            if (usuario.DatosUsuario == null)
            {
                MjeError("Debe completar sus datos personales antes de agregar una dirección.");
                return;
            }

            // Validar que los campos requeridos estén completos (opcional)
            if (string.IsNullOrWhiteSpace(txtCalle.Text) || string.IsNullOrWhiteSpace(txtAltura.Text) || string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                MjeError("Complete al menos Calle, Nro. y Ciudad para agregar una dirección.");
                return;
            }

            Direccion direccion = new Direccion
            {
                Calle = txtCalle.Text.Trim(),
                Altura = txtAltura.Text.Trim(),
                Departamento = txtDto.Text.Trim(),
                Piso = txtPiso.Text.Trim(),
                Ciudad = txtCiudad.Text.Trim(),
                CodPostal = int.TryParse(txtCP.Text, out int cp) ? cp : 0
            };

            DireccionNegocio dNeg = new DireccionNegocio();
            dNeg.InsertarDireccion(usuario.Id, direccion);

            usuario.Direcciones = dNeg.ListarDirecciones(usuario.Id);
            Session["usuario"] = usuario;

            rptDirecciones.DataSource = usuario.Direcciones;
            rptDirecciones.DataBind();
        }

        protected void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            if (!string.IsNullOrWhiteSpace(txtClaveNueva.Text) &&
                txtClaveNueva.Text == txtClaveRepetir.Text)
            {
                UsuarioNegocio uNeg = new UsuarioNegocio();
                uNeg.actualizarContraseñaPorEmail(usuario.Email, txtClaveNueva.Text);
                MjeError("Contraseña actualizada.");
            }
            else
            {
                MjeError("Las contraseñas no coinciden.");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                !int.TryParse(txtDni.Text, out int dni) || dni <= 0)
            {
                MjeError("Debe completar los campos.");
                return;
            }

            DireccionNegocio dNeg = new DireccionNegocio();
            var direcciones = dNeg.ListarDirecciones(usuario.Id);
            if (direcciones == null || direcciones.Count == 0)
            {
                MjeError("Debe agregar al menos una dirección.");
                return;
            }

            Response.Redirect("~/Pedidos.aspx");
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
        }

        protected void rptDirecciones_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            // Implementar si se desea eliminar direcciones desde el Repeater
        }
    }
}