﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.HtmlControls;
using Dominio;
using Negocio;

namespace WebImprenta.Paginas
{
    public partial class PageRecepcion : System.Web.UI.Page
    {
        public List<Pedido> ListaPedidos { get; set; }
        public List<EstadoPedido> ListaEstadoPedidos { get; set; }
        protected string textoRelleno = "";
        //protected Pedido PedidoSeleccionado { get; set; }
        protected Pedido PedidoSeleccionado
        {
            get { return ViewState["PedidoSeleccionado"] as Pedido; }
            set { ViewState["PedidoSeleccionado"] = value; }
        }
        public List<Dominio.Mensajes> ListaMensajes { get; set; } //porque existe una página que se llama Mensajes

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
                DevolverModal();
                try
                {
                    PedidoNegocio pNegocio = new PedidoNegocio();
                    ListaPedidos = pNegocio.lista();
                    HojaNegocio hNegocio = new HojaNegocio();
                    EstadoPedidoNegocio eNegocio = new EstadoPedidoNegocio();
                    ListaEstadoPedidos = eNegocio.lista();


                    grillaPedidos.DataSource = ListaPedidos;
                    grillaPedidos.DataBind();

                    //if (!IsPostBack)
                    //{
                    //    PedidoNegocio pNegocio = new PedidoNegocio();
                    //    ListaPedidos = pNegocio.lista();

                    //    grillaPedidos.DataSource = ListaPedidos;
                    //    grillaPedidos.DataBind();

                    //    mensajeError.Text = ListaPedidos[0].NombreUsuario;
                    //}
                    int contPedidosInconclusos = 0;
                    if (!IsPostBack)
                    {
                        foreach (var Pedido in ListaPedidos)
                        {
                            if (Pedido.Estado != "Listo.") contPedidosInconclusos++;
                        }

                        //---------- Modificación dinámica de la cantidad e pedidos inconclusos ----------
                        if (contPedidosInconclusos == 0)
                        {
                            string script = "Id('divAdvertencia').style = 'opacity:0;' ";
                            ClientScript.RegisterStartupScript(this.GetType(), "Advertencia", script, true);
                        }
                        else
                        {
                            string script = "Id('divAdvertencia').style = 'opacity:1;'; Id('divAdvertencia').innerHTML = " + contPedidosInconclusos + ";";
                            ClientScript.RegisterStartupScript(this.GetType(), "Advertencia", script, true);
                        }
                        ////-----------------------------------------------------------------------------------

                        foreach (var EstadoPedido in ListaEstadoPedidos)
                        { ddlListaEstados.Items.Add(EstadoPedido.Descripcion); }
                    }

                }
                catch (Exception ex)
                { MjeError("Hubo un error en la carga de la página. Intentelo más tarde. Error: " + ex.Message); }
            }
        }
        
        protected void grillaPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DevolverModal();

                long IdPedidoSeleccionado = (long)grillaPedidos.SelectedDataKey.Value;
                PedidoSeleccionado = ListaPedidos.Find(x => x.IdPedido == IdPedidoSeleccionado);
                //----------- Id para cambiar el estado -----------
                TextoModal.Text = PedidoSeleccionado.NombreUsuario;

                //----------- Detalle del pedido seleccionado -----------
                

                lblEstadoPedido.Text = PedidoSeleccionado.Estado;
                lblnroPedido.Text = PedidoSeleccionado.IdPedido.ToString();
                lblNombreU.Text = PedidoSeleccionado.NombreUsuario;
                lblTamanio.Text = PedidoSeleccionado.Hoja.Tamaño;
                lblTipo.Text = PedidoSeleccionado.Hoja.TipoPapel;
                lblGramaje.Text = PedidoSeleccionado.Hoja.Gramaje;
                lblColor.Text = PedidoSeleccionado.Calidad.Color;
                lblCalidad.Text = PedidoSeleccionado.Calidad.Tipo;
                lblCopasXhoja.Text = PedidoSeleccionado.CopiaPorHoja.ToString();
                lblCantidad.Text = PedidoSeleccionado.Copias.ToString();
                if (PedidoSeleccionado.Margenes)
                    lblMargen.Text = "Si";
                else
                    lblMargen.Text = "No";
                lblPreciPedido.Text = "$" + PedidoSeleccionado.PrecioPedido.ToString("F2");

                MensajesNegocio mNegocio = new MensajesNegocio();
                ListaMensajes = mNegocio.listar();

                List<Dominio.Mensajes> listaFiltrada = ListaMensajes.FindAll(x => x.IdPedido == IdPedidoSeleccionado);

                ContenedorMensajes.InnerHtml = "";

                foreach (var item in listaFiltrada)
                {

                    switch (item.TipoUsuario)
                    {
                        case 1:
                            ContenedorMensajes.InnerHtml += "<div class=\"margen-bottom-1vw txt-oblique txt-color-blanco-1 entero\"><span class=\"txt-bold-oblique  txt-color-resaltado-2\">" + item.Nombre + "</span> <span class=\"txt-oblique  txt-color-blanco-2\">" + item.Fecha + "</span><br>" + item.Mensaje + "</div>";
                            break;
                        case 2:
                            ContenedorMensajes.InnerHtml += "<div class=\"margen-bottom-1vw margen-left-5vw txt-oblique txt-color-blanco-1 entero\"><span class=\"txt-bold-oblique  txt-color-resaltado-1\">" + item.Nombre + "(Operador/a)</span> <span class=\"txt-oblique  txt-color-blanco-2\">" + item.Fecha + "</span><br>" + item.Mensaje + "</div>";
                            break;
                    }
                }
                

                ReferenciaPedido.Value = IdPedidoSeleccionado.ToString();


                //"<p>"+ Server.HtmlEncode(TextoC) + "</p>";

            }
            catch (Exception ex)
            { MjeError("Surgió un problema en la selección del pedido. Intentelo más tarde. Error: "+ex.ToString()); }

        }

        protected void btnAceptarModal_Click(object sender, EventArgs e)
        {
            try
            {
                PedidoNegocio PNegocio = new PedidoNegocio();
                //EstadoPedidoNegocio eNegocio = new EstadoPedidoNegocio();

                //ListaEstadoPedidos = eNegocio.listar();

                if (!(ddlListaEstados.SelectedValue is null))
                {
    //////////////////////revisar/////////////////////////////
                    PNegocio.ModificarEstado(PedidoSeleccionado.IdPedido, ddlListaEstados.SelectedValue);
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    limpiarModal();
                    TextoModal.Text = "Debe seleccionar un estado para el pedido.";
                }
            }
            catch (Exception ex)
            { MjeError("Surgio un problema al itentar cambiar el estado. Intentelo más tarde. Error: " + ex.Message); }
        }

        protected void EnviarMensaje_Click(object sender, EventArgs e)
        {
            try
            {
                MensajesNegocio nuevoMensaje = new MensajesNegocio();

                //if (!(MensajeAenviar.Text == "" || ReferenciaPedido.Value=="" || ReferenciaIdUsuario.Text==""))
                if (!string.IsNullOrWhiteSpace(MensajeAenviar.Text) &&
                    !string.IsNullOrWhiteSpace(ReferenciaPedido.Value) &&
                    !string.IsNullOrWhiteSpace(ReferenciaIdUsuario.Text))
                {
                    nuevoMensaje.EnviarMensaje(int.Parse(ReferenciaPedido.Value), int.Parse(ReferenciaIdUsuario.Text), MensajeAenviar.Text);
                }
                else
                {
                    MjeError("Falta cargar uno de los datos para poder enviar el mensaje. Intentelo más tarde.");
                }
                MensajeAenviar.Text = "";
            }
            catch (Exception ex)
            { MjeError("No se pudo enviar el mensaje. Intentelo más tarde. Error: " + ex.Message); }
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
            ddlListaEstados.Style["display"] = "none";
            btnAceptarModal.Style["display"] = "none";
        }
        protected void DevolverModal()
        {
            string script = "Id('ventana-modal').style = 'display:none;';";
            ClientScript.RegisterStartupScript(this.GetType(), "devolver", script, true);
            ddlListaEstados.Style["display"] = "flex";
            btnAceptarModal.Style["display"] = "flex";
        }
    }
}