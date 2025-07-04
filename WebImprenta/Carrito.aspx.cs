using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using MercadoPago.Resources;
using Negocio;
using MercadoPago.DataStructures.Preference;

namespace WebImprenta
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Session.Add("error", "Necesitas loguearte.");
                Response.Redirect("Error.aspx", false);
                return; // Importante: salir aquí
            }

            if (!IsPostBack)
            {
                try
                {
                    PlaceHolder navbar = (PlaceHolder)this.Master.FindControl("NavBarPlaceHolder");

                    if (navbar != null)
                    {
                        navbar.Visible = false;
                    }

                    if (string.IsNullOrEmpty(MercadoPago.SDK.AccessToken))
                    {
                        //MercadoPago.SDK.AccessToken = "...";
                    }

                    Usuario usuario = (Usuario)Session["Usuario"];

                    if (usuario == null)
                    {
                        // Por seguridad, regresamos al login
                        Response.Redirect("Login.aspx", false);
                        return;
                    }

                    DireccionNegocio negocioDireccion = new DireccionNegocio();

                    var direcciones = negocioDireccion.ListarDirecciones(usuario.Id);
                    usuario.Direcciones = direcciones ?? new List<Direccion>();

                    // Volvemos a guardar el objeto actualizado en la sesión
                    Session["Usuario"] = usuario;

                    rptDirecciones.DataSource = usuario.Direcciones;
                    rptDirecciones.DataBind();

                }
                catch (MercadoPago.MPConfException)
                {
                    // Ya estaba seteado, no hacemos nada para no romper
                }
                catch (Exception ex)
                {
                    // Según tu aplicación, podrías mostrar el error o mandarle a Error.aspx
                    lblError.Text = "Ocurrió un error: " + ex.Message;
                    lblError.Visible = true;
                }
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                Preference preference = new Preference();

                Item item = new Item()
                {
                    Title = "Producto",
                    Quantity = 1,
                    CurrencyId = MercadoPago.Common.CurrencyId.ARS,
                    UnitPrice = (decimal)2000.00
                };

                preference.Items.Add(item);
                preference.Save();

                Response.Redirect(preference.InitPoint);
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al procesar el pago: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPrincipal.aspx", false);
        }



        protected void ConfirmarDirección_Click(object sender, EventArgs e)
        {
            //    Usuario usuario = (Usuario)Session["Usuario"];
            //    usuario.Direcciones.ToString();
            //    txtError = usuario.Direcciones.Find(id);

        }
        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int idDireccion = int.Parse(e.CommandArgument.ToString());

                Usuario usuario = (Usuario)Session["Usuario"];
                if (usuario == null)
                {
                    txtError.Text = "Usuario no encontrado.";
                    txtError.Visible = true;
                    return;
                }

                var direccionSeleccionada = usuario.Direcciones.Find(d => d.Id == idDireccion);
                if (direccionSeleccionada == null)
                {
                    txtError.Text = "No se encontró la dirección seleccionada.";
                    txtError.Visible = true;
                    return;
                }

                // Guardás el ID en sesión o hacés lo que necesites
                Session["direccionSeleccionada"] = idDireccion;

                txtError.Text = "Dirección seleccionada correctamente.";
                txtError.ForeColor = System.Drawing.Color.Green;
                txtError.Visible = true;
            }
            catch (Exception ex)
            {
                txtError.Text = "Error al seleccionar la dirección: " + ex.Message;
                txtError.Visible = true;
            }
        }

    }
}