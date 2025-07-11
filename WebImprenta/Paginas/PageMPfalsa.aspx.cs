using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MercadoPago.Resources;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Common;

namespace WebImprenta.Paginas
{
    public partial class PageMPfalsa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
                return;
            }
            else{
                Preference respuesta = new Preference();
                respuesta= (Preference)Session["DatosMP"];

                //{
                //    Title = "Pedido de Impresion",
                //    Quantity = 1,
                //    CurrencyId = CurrencyId.ARS,
                //    UnitPrice = total
                //};

                tbxRespuesta.Text += "{\n";
                tbxRespuesta.Text += "\tTitle: " + respuesta.Items[0].Title;
                tbxRespuesta.Text += "\n\tQuantity: " + respuesta.Items[0].Quantity.ToString();
                tbxRespuesta.Text += "\n\tCurrencyId: " + respuesta.Items[0].CurrencyId.ToString();
                tbxRespuesta.Text += "\n\tUnitPrice: " + respuesta.Items[0].UnitPrice.ToString();
                tbxRespuesta.Text += "\n}";
            }

        }
    }
}