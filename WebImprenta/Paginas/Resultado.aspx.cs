using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebImprenta.Paginas
{
    public partial class Resultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string estado = Request.QueryString["status"];

                if (estado == "approved")
                {
                    lblResultado.Text = "La solicitud fue aprobada.";
                }
                else if (estado == "rejected")
                {
                    lblResultado.Text = "La solicitud fue rechazada.";
                }
                else
                {
                    lblResultado.Text = "Estado desconocido.";
                }
            }
        }

    }
}