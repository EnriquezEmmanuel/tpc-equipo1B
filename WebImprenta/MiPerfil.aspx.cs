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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
                return;
            }
            //////////////////////////////////////////////////////////

            //Usuario usuario = new Usuario();
            //UsuarioNegocio uNegocio = new UsuarioNegocio();
            //usuario = (uNegocio.listar()).Find(x=> x.Email == "chizorengo.@hotmail.com");

            //////////////////////////////////////////////////////////
            if (!IsPostBack)
            {
                // Obtengo usuario de sesión con la misma clave
                Usuario usuario = (Usuario)Session["usuario"];


                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                
                DireccionNegocio negocioDireccion = new DireccionNegocio();

                // Obtener direcciones desde BD para este usuario
                usuario.Direcciones = negocioDireccion.ListarDirecciones(usuario.Id);

                // Si el usuario NO tiene direcciones, se añade una dirección vacío
                if (usuario.Direcciones == null ||
                    usuario.Direcciones.Count == 0)
                {
                    usuario.Direcciones = new List<Direccion> { new Direccion() };
                }

                // Actualizamos sesión y Bind
                Session["usuario"] = usuario;

                rptDirecciones.DataSource = usuario.Direcciones;
                rptDirecciones.DataBind();


                CargarDatosUsuario();

            }
        }


        protected void btnGuardarDirecciones_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            if (usuario == null)
            {
                Session.Add("error", "Debes logearte");
                Response.Redirect("Error.aspx", false);
            }

            string calle = txtCalleNueva.Text.Trim(); //el trim quita los caracteres en blanco del princio al final del objeto actual
            string altura = txtAlturaNueva.Text.Trim();
            string depto = txtDepartamentoNuevo.Text.Trim();
            string piso = txtPisoNuevo.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();

            int codPostal;
            if (!int.TryParse(txtCodigoPostal.Text.Trim(), out codPostal) || codPostal <= 0)
            {
                lblError.Text = "El Código Postal debe ser un número mayor a cero.";
                lblError.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(calle) || string.IsNullOrWhiteSpace(altura) ||
                string.IsNullOrWhiteSpace(ciudad))
            {
                lblError.Text = "Debes completar los campos obligatorios: Calle, Altura y Ciudad.";
                lblError.Visible = true;
                return;
            }

            Direccion direccion = new Direccion
            {
                Calle = calle,
                Altura = altura,
                Departamento = depto,
                Piso = piso,
                CodPostal = codPostal,
                Ciudad = ciudad

            };
            // Guarda en la base 
            DireccionNegocio negocio = new DireccionNegocio();
            negocio.InsertarDireccion(usuario.Id, direccion);

            //Actualizo la sesion
            usuario.Direcciones = negocio.ListarDirecciones(usuario.Id);
            Session["usuario"] = usuario;
            // Posiblemente dar un mensaje de éxito o volver a cargar
            Response.Redirect("MiPerfil.aspx");

        }
        private void CargarDatosUsuario()
        {
            Usuario usuario = (Usuario)Session["usuario"];
            DatosUsuarioNegocio datosNegocio = new DatosUsuarioNegocio();
            DatosUsuario datos = datosNegocio.obtenerUsuarioDatos(usuario.Id);

            if (datos != null)
            {
                txtNombre.Text = datos.Nombre;
                txtApellido.Text = datos.Apellido;
                txtDni.Text = datos.Dni.ToString();

                usuario.DatosUsuario = datos;
                Session["usuario"] = usuario;
            }
        }

        protected void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            // crear la insertarUsuarioDatos ya tengo el obtener datos del cliente

            Usuario usuario = (Usuario)Session["usuario"];
            DatosUsuarioNegocio datosNegocio = new DatosUsuarioNegocio();
            bool exito;

            if (usuario.DatosUsuario == null)
            {
                usuario.DatosUsuario = new DatosUsuario();
            }

            // Asignás los datos que vienen del formulario
            usuario.DatosUsuario.Nombre = txtNombre.Text;
            usuario.DatosUsuario.Apellido = txtApellido.Text;
            usuario.DatosUsuario.Dni = int.Parse(txtDni.Text);

            // Guardás en la sesión
            Session["usuario"] = usuario;

            // Decidís si insertar o actualizar
            if (datosNegocio.obtenerUsuarioDatos(usuario.Id) == null)
            {
                exito = datosNegocio.insertarUsuarioDatos(usuario);
            }
            else
            {
                datosNegocio.actualizarUsuarioDatos(usuario);
                exito = true;
            }

            if (exito)
            {
                lblError.Text = "Datos actualizados correctamente.";
                lblError.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblError.Text = "Error al guardar los datos.";
                lblError.ForeColor = System.Drawing.Color.Red;
            }

            lblError.Visible = true;

        }




        protected void rptDirecciones_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    int idDireccion = Convert.ToInt32(e.CommandArgument);

                    DireccionNegocio negocio = new DireccionNegocio();
                    negocio.EliminarDireccion(idDireccion);

                    // Actualizar lista
                    Usuario usuario = (Usuario)Session["usuario"];
                    usuario.Direcciones = negocio.ListarDirecciones(usuario.Id);
                    Session["usuario"] = usuario;

                    rptDirecciones.DataSource = usuario.Direcciones;
                    rptDirecciones.DataBind();
                }
                catch (Exception ex)
                {


                    Session.Add("error", ex.ToString());
                }
            }
        }
    }


}
