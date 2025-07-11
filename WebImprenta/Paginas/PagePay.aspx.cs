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
using MercadoPago.Common;


namespace WebImprenta.Paginas
{
    public partial class PagePay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("~/Error.aspx", false);
                return;
            }

            //string BloquePagAnterior = Session["Domicilio"].ToString() + ", " + Session["Repartidor"].ToString();
            //ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('" + BloquePagAnterior + "');", true);

            if (!IsPostBack)
            {

                Usuario User = (Usuario)Session["Usuario"];
                lblMail.Text = User.Email;

                lblTamaño.Text = Session["Tamaño"]?.ToString();
                lblTipoPapel.Text = Session["TipoPapel"]?.ToString();
                lblGramaje.Text = Session["Gramaje"]?.ToString();

                lblColor.Text = Session["Color"]?.ToString();
                lblCalidad.Text = Session["Calidad"]?.ToString();
                lblDobleCara.Text = Convert.ToBoolean(Session["DobleCara"]) ? "Doble cara" : "Simple";

                lblCopiasPorHoja.Text = Session["CopiasPorHoja"]?.ToString();
                lblNumeroCopias.Text = Session["NumeroCopias"]?.ToString();
                lblMargen.Text = Session["Margen"]?.ToString() == "true" ? "Sí" : "No";

                decimal subtotal = Convert.ToDecimal(Session["Subtotal"] ?? 0);
                decimal envio = Convert.ToDecimal(Session["CostoEnvio"] ?? 0);
                decimal total = subtotal + envio;

                lblPrecioImpresion.InnerText = "$" + subtotal.ToString("0.00");
                lblPrecioEnvio.InnerText = "$" + envio.ToString("0.00");
                lblPreTotal.InnerText = "$" + total.ToString("0.00");
            }
        }


        protected void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal subtotal = Convert.ToDecimal(Session["Subtotal"] ?? 0);
                decimal envio = Convert.ToDecimal(Session["CostoEnvio"] ?? 0);
                decimal total = subtotal + envio;

                Preference preference = new Preference();

                Item item = new Item()
                {
                    Title = "Pedido de Impresion",
                    Quantity = 1,
                    CurrencyId = CurrencyId.ARS,
                    UnitPrice = total
                };

                preference.Items.Add(item);

                preference.BackUrls = new BackUrls()
                {
                    Success = "https://tusitio.com/Paginas/Resultado.aspx?status=success",
                    Failure = "https://tusitio.com/Paginas/Resultado.aspx?status=failure",
                    Pending = "https://tusitio.com/Paginas/Resultado.aspx?status=pending"
                };

                preference.AutoReturn = AutoReturnType.approved;
                preference.Save();

                //Response.Redirect(preference.InitPoint); //Cuando funcione
                Session["DatosMP"] = (Preference)preference;
                Response.Redirect("PageMPfalsa.aspx");

            }
            catch (Exception ex)
            {
                // Podés mostrar el error si querés
                // lblError.Text = "Ocurrió un error al procesar el pago: " + ex.Message;
            }
        }




        protected void btnAprobar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Resultado.aspx?status=approved");
        }

        protected void btnRechazar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Resultado.aspx?status=rejected");
        }
    }


}
