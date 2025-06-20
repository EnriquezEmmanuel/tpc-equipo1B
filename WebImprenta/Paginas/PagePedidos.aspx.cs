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
    
    public partial class gestion_catalogo : System.Web.UI.Page
    {
        public List<Pedido> ListaPedidos { get; set; }
        public List<EstadoPedido> ListaEstadoPedidos { get; set; }
        public int contFecha = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PedidoNegocio pNegocio = new PedidoNegocio();
                ListaPedidos = pNegocio.lista();

                EstadoPedidoNegocio eNegocio = new EstadoPedidoNegocio();
                ListaEstadoPedidos = eNegocio.lista();

                grillaPedidos.DataSource = ListaPedidos;
                grillaPedidos.DataBind();

                int contPedidosInconclusos=0;

                if (! IsPostBack) {
                    foreach (var Pedido in ListaPedidos)
                    {
                        //ddlPedido.Items.Add(Pedido.IdPedido.ToString() + ": " + Pedido.Email.ToString()); 
                        ddlPedido.Items.Add(Pedido.IdPedido.ToString());
                        if (Pedido.Estado != "Listo.") contPedidosInconclusos++;
                    }

                    //---------- Modificación dinámica de la cantidad e pedidos inconclusos ----------
                    if (contPedidosInconclusos == 0)
                    {
                        string script = "Id('divAdvertencia').style = style = 'opacity:0;' ";
                        ClientScript.RegisterStartupScript(this.GetType(), "Advertencia", script, true);
                    }
                    else
                    {
                        string script = "Id('divAdvertencia').style = 'opacity:1;'; Id('divAdvertencia').innerHTML = " + contPedidosInconclusos + ";";
                        ClientScript.RegisterStartupScript(this.GetType(), "Advertencia", script, true);
                    }
                    //-----------------------------------------------------------------------------------

                    foreach (var EstadoPedido in ListaEstadoPedidos)
                    { ddlListaEstados.Items.Add(EstadoPedido.Descripcion); }
                }
            }
            catch (Exception)
            { MjeError(); }
               

        }
        
        //protected void btnSeleccionarFecha_Click(object sender, EventArgs e)
        //{ TextoModal.Text = ddlPedido.SelectedValue; }

        protected void btnAceptarModal_Click(object sender, EventArgs e)
        {
            try
            {                
                PedidoNegocio PNegocio = new PedidoNegocio();
                if (!(ddlListaEstados.SelectedValue is null))
                {
                    TextoModal.Text = ddlPedido.SelectedValue;
                    PNegocio.ModificarEstado(int.Parse(TextoModal.Text), ddlListaEstados.SelectedValue);
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    limpiarModal();
                    TextoModal.Text = "Debe seleccionar un pedido.";
                }
            }
            catch (Exception)
            {  MjeError(); }
        }
        protected void MjeError()
        {
            limpiarModal();
            TextoModal.Text = "Hubo un error inesperado. Vuelva a intentar más tarde.";
        }
        protected void limpiarModal()
        {
            string script = "Id('ventana-modal').style = 'display:flex;';"; /* Id('parrafo-modal').style = 'display:none;';";*/
            ClientScript.RegisterStartupScript(this.GetType(), "alerta", script, true);
            ddlListaEstados.Style["display"] = "none";
            btnAceptarModal.Style["display"] = "none";
        }
    }
}