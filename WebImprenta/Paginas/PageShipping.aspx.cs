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
    public partial class PageShipping : System.Web.UI.Page
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
                Usuario User = (Usuario)Session["usuario"];

                NegocioMetodoEnvio meNegocio = new NegocioMetodoEnvio();
                List<MetodoEnvio> listaRepartidor = meNegocio.listar();

                try
                {
                    if (!IsPostBack)
                    {
                        foreach (var item in User.Direcciones)
                        {
                            if (item.Activo)
                            {
                                string texto = item.Calle + " " + item.Altura + ", " + item.Ciudad;
                                string valor = item.Id.ToString(); // este es el equivalente a value del Select(html)
                                ddlDomicilios.Items.Add(new ListItem(texto, valor));
                            }
                        }
                        foreach (var item in listaRepartidor)
                        {
                            ddlRepartidor.Items.Add(item.Metodo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MjeError("Hubo un error. Inténtelo más tarde. Error: " + ex.Message);
                }
            }   
        }

        protected void ContinuarEnvio_Click(object sender, EventArgs e)
        {
            if(ddlDomicilios.SelectedValue != null && ddlRepartidor.SelectedValue != null )
            {
                //IdDireccion.Text = ddlDomicilios.SelectedValue;  //solo de muestra, esto va a Session
                //MetodoEnvio.Text = ddlRepartidor.SelectedValue;  //solo de muestra, esto va a Session

                Session.Add("Domicilio", ddlDomicilios.SelectedValue);
                Session.Add("Repartidor", ddlRepartidor.SelectedValue);
                Session["CostoEnvio"] = 1350;
                Response.Redirect("PagePay.aspx");
            }
            else
            {
                MjeError("No se cargó alguno de los datos, seleccione nuevamente.");
            }
        }
        protected void ContinuarSinEnvio_Click(object sender, EventArgs e)
        {
            if (ddlDomicilios.SelectedValue != null && ddlRepartidor.SelectedValue != null)
            {
                //IdDireccion.Text = ddlDomicilios.SelectedValue;  //solo de muestra, esto va a Session
                //MetodoEnvio.Text = DireccionLocal.Text;           //solo de muestra, esto va a Session

                Session.Add("Domicilio", ddlDomicilios.SelectedValue);
                Session.Add("Repartidor", DireccionLocal.Text);
                Session["CostoEnvio"] = 0;
                Response.Redirect("PagePay.aspx");
            }
            else
            {
                MjeError("No se cargó alguno de los datos, seleccione nuevamente.");
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