using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using DocumentFormat.OpenXml.Packaging;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;

using Dominio;
using Negocio;
namespace WebImprenta
{
    public partial class Pedidos : System.Web.UI.Page
    {
        //public List<Usuario> ListaUsuarios {get;set;}
        public string Email { get; set; }
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
                Usuario User = (Usuario)Session["Usuario"];
                ////// Usuario codeado reemplaza Session para pruebas

                //UsuarioNegocio listaUsuariosXX = new UsuarioNegocio();
                //Usuario User = listaUsuariosXX.listar().Find(x => x.Id == 1 );

                //////
                PedidoNegocio pNegocio = new PedidoNegocio();
                List<Pedido> ListaPedidos = new List<Pedido>();
                ListaPedidos = pNegocio.BuscarPedidos(User.Email);

                if (ListaPedidos.Count != 0)    // valida si está vacía la lista
                {
                    ContenedorPedidos.InnerHtml = "";
                    string margenes = "";
                    foreach (var item in ListaPedidos)
                    {
                        if (item.Margenes) margenes = "Si"; else margenes = "No";
                        ContenedorPedidos.InnerHtml += "<div class=\"tablon-claro contenedor-v alineacion-centrado-centrado entero txt-em9\">" +
                            "<h2 class=\"txt-familia-Rto txt-bold txt-1em3 entero\">Pedido #<span id=\"txt-numero-pedido\">" + item.IdPedido.ToString() + "</span>	|	<span>" + item.NombreUsuario + "</span>	|	<span id=\"txt-estado-pedido\" class=\"txt-normal txt-familia-Rto-Slab\">" + item.Estado + "</span></h2>" +
                            "<div class=\"contenedor-h alineacion-around-inicio entero \">" +
                            "<div><h3>Hoja</h3><ul><li class=\"margen-bottom-0em3\">Tamaño: " + item.Hoja.Tamaño + "</li><li class=\"margen-bottom-0em3\">Tipo:" + item.Hoja.TipoPapel + "</li><li class=\"margen-bottom-0em3\">Gramaje: " + item.Hoja.Gramaje + "</li></ul></div>" +
                            "<div><h3>Calidad</h3><ul><li class=\"margen-bottom-0em3\">" + item.Calidad.Color + "</li><li class=\"margen-bottom-0em3\">" + item.Calidad.Tipo + "</li></ul></div>" +
                            "<div><h3>Detalles de <br>impresión</h3><ul><li class=\"margen-bottom-0em3\">Copias por hoja: " + item.CopiaPorHoja.ToString() + "</li><li class=\"margen-bottom-0em3\">Cantidad de copias: " + item.Copias.ToString() + "</li><li class=\"margen-bottom-0em3\">Margen (2mm): " + margenes + "</li></ul></div>" +
                            "<div class=\"contenedor-v alineacion-final-inicio\"><h3>Precio</h3><p>" + item.PrecioPedido.ToString() + "</p><h3>Envío</h3><p>$1000</p></div>" +
                            "</div></div>";

                        //No está funcionando el precio.
                    }
                    //txtValidacion.Text = ListaPedidos[2].PrecioPedido.ToString();
                }
            }
            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["usuario"];

                if (usuario == null)
                {
                    // Por seguridad, regresamos al login
                    Response.Redirect("Login.aspx", false);
                    return;
                }
                cargarSeleccionables();
                LimpiarArchivosTemporales();
                //CargarPedidos();

                txtNumeroCopias.Attributes["type"] = "number";
                txtNumeroCopias.Attributes["min"] = "1";
                txtNumeroCopias.Attributes["step"] = "1";

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "recalcular", "setTimeout(calcularSubtotal, 100);", true);
            }
            DevolverModal();
        }
        private void cargarSeleccionables()
        {
            HojaNegocio hojaNegocio = new HojaNegocio();
            ddlTamaño.DataSource = hojaNegocio.listarTamaños();
            ddlTamaño.DataBind();
            ddlTipoPapel.DataSource = hojaNegocio.listarTiposPapel();
            ddlTipoPapel.DataBind();
            var gramajes = hojaNegocio.listarGramajes()
            .OrderBy(g =>
            {
                // Extrae la parte numérica antes de "grs" y la convierte a int
                string numero = new string(g.TakeWhile(char.IsDigit).ToArray());
                return int.TryParse(numero, out int n) ? n : int.MaxValue;
            })
            .ToList();
            ddlGramaje.DataSource = gramajes;
            ddlGramaje.DataBind();
        }
        private decimal precioBase = 0;

        protected void ActualizarPrecio(object sender, EventArgs e)
        {
            if (ddlTamaño.SelectedValue != "" && ddlTipoPapel.SelectedValue != "" && ddlGramaje.SelectedValue != "")
            {
                HojaNegocio negocio = new HojaNegocio();
                precioBase = negocio.obtenerPrecio(ddlTamaño.SelectedValue, ddlTipoPapel.SelectedValue, ddlGramaje.SelectedValue);
                lblPrecioHoja.Text = "$" + precioBase.ToString("0.00");

                ViewState["PrecioBase"] = precioBase;
            }
            else
            {
                lblPrecioHoja.Text = "$";
                ViewState["PrecioBase"] = null;
            }

            ActualizarPrecioCalidad();
            ActualizarSubtotal(); ;
        }

        private void ActualizarPrecioCalidad()
        {
            if (ViewState["PrecioBase"] == null)
                return;

            if (ddlColor.SelectedValue == "" || ddlCalidad.SelectedValue == "" || ddlDobleCara.SelectedValue == "")
                return;

            string color = ddlColor.SelectedValue;
            string calidad = ddlCalidad.SelectedValue;
            bool dobleCara = ddlDobleCara.SelectedValue == "true";

            CalidadNegocio negocio = new CalidadNegocio();
            decimal porcentaje = negocio.obtenerPorcentaje(color, calidad, dobleCara);

            decimal precioBase = (decimal)ViewState["PrecioBase"];
            decimal precioCalidad = precioBase * porcentaje;
            lblPrecioCalidad.Text = "$" + precioCalidad.ToString("0.00");
            ActualizarSubtotal();
        }
        protected void ActualizarPrecioCalidad(object sender, EventArgs e)
        {
            ActualizarPrecioCalidad();
        }
        private void ActualizarSubtotal()
        {
            if (ViewState["PrecioBase"] == null)
            {
                lblPrecioDetalles.Text = "$";
                lblSubtotal.Text = "$";
                return;
            }

            decimal precioHoja = (decimal)ViewState["PrecioBase"];
            decimal precioCalidad = 0m;

            if (!decimal.TryParse(lblPrecioCalidad.Text.Replace("$", ""), out precioCalidad))
            {
                precioCalidad = 0;
            }

            int copias = 1;
            if (!int.TryParse(txtNumeroCopias.Text, out copias) || copias < 1)
            {
                copias = 1;
            }

            int paginas = 1;
            if (!int.TryParse(hdnPaginas.Value, out paginas) || paginas < 1)
            {
                paginas = 1;
            }

            decimal precioDetalles = (precioHoja + precioCalidad) * copias;
            decimal subtotal = precioDetalles * paginas;

            lblPrecioDetalles.Text = "$" + precioDetalles.ToString("0.00");
            lblSubtotal.Text = "$" + subtotal.ToString("0.00");

            ViewState["PrecioDetalles"] = precioDetalles;
            ViewState["Subtotal"] = subtotal;

            hdnSubtotal.Value = subtotal.ToString();
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            string rutaTemporal = hdnRutaArchivoTemporal.Value;
            string enlaceOriginal = txtLinkArchivo.Text.Trim();
            bool guardadoCorrectamente = false;
            string mensajeError = "";

            if (string.IsNullOrEmpty(rutaTemporal) || !File.Exists(rutaTemporal))
            {
                lblMensajeArchivo.Text = "No hay archivo cargado para guardar.";
                return;
            }

            try
            {
                string extension = System.IO.Path.GetExtension(rutaTemporal).ToLower();
                bool esImagen = extension == ".jpg" || extension == ".jpeg" || extension == ".png";
                bool esArchivoDesdeDispositivo = fileUpload.HasFile;
                bool esEnlace = !string.IsNullOrEmpty(enlaceOriginal) && !esArchivoDesdeDispositivo;

                if (esEnlace && !esImagen)
                {
                    if (Uri.IsWellFormedUriString(enlaceOriginal, UriKind.Absolute))
                    {
                        Session["ArchivoEnlace"] = enlaceOriginal;
                        guardadoCorrectamente = true;
                        lblMensajeArchivo.Text = "Enlace guardado correctamente.";
                    }
                    else
                    {
                        mensajeError = "El enlace no es válido.";
                    }
                }
                else
                {
                    // Es archivo local o imagen desde enlace
                    string rutaArchivos = Server.MapPath("~/Archivos/");
                    if (!Directory.Exists(rutaArchivos)) Directory.CreateDirectory(rutaArchivos);

                    string nombreArchivo = System.IO.Path.GetFileName(rutaTemporal);
                    string rutaDefinitiva = System.IO.Path.Combine(rutaArchivos, nombreArchivo);

                    if (File.Exists(rutaDefinitiva))
                    {
                        string nombreSinExt = System.IO.Path.GetFileNameWithoutExtension(nombreArchivo);
                        string ext = System.IO.Path.GetExtension(nombreArchivo);
                        string nuevoNombre = $"{nombreSinExt}_{Guid.NewGuid()}{ext}";
                        rutaDefinitiva = System.IO.Path.Combine(rutaArchivos, nuevoNombre);
                    }

                    File.Move(rutaTemporal, rutaDefinitiva);

                    Session["ArchivoSubido"] = "~/Archivos/" + System.IO.Path.GetFileName(rutaDefinitiva);
                    guardadoCorrectamente = true;
                    lblMensajeArchivo.Text = "Archivo guardado correctamente.";
                }


                hdnRutaArchivoTemporal.Value = "";
                hdnUrlImagenSubida.Value = "";
                LimpiarArchivosTemporales();

                //  Guarda los campos 
                Session["Tamaño"] = ddlTamaño.SelectedValue;
                Session["TipoPapel"] = ddlTipoPapel.SelectedValue;
                Session["Gramaje"] = ddlGramaje.SelectedValue;

                Session["Color"] = ddlColor.SelectedValue;
                Session["Calidad"] = ddlCalidad.SelectedValue;
                Session["DobleCara"] = ddlDobleCara.SelectedValue;


                string copiasPorHoja = Request.Form["inputCopiasPorHoja"];
                string numeroCopias = Request.Form["txtNumeroCopias"];
                string margen = ddlMargen.SelectedValue;
                string posicion = ddlPosicion.SelectedValue;

                Session["CopiasPorHoja"] = copiasPorHoja;
                Session["NumeroCopias"] = numeroCopias;
                Session["Margen"] = margen;
                Session["Posicion"] = posicion;

                decimal subtotal = 0;
                decimal.TryParse(hdnSubtotal.Value, out subtotal);
                Session["Subtotal"] = subtotal;

                if (guardadoCorrectamente)
                {
                    // Aca tiene que Redirigir a pagina envios
                    Response.Redirect("Paginas/PageShipping.aspx");
                }
                else
                {
                    lblMensajeArchivo.Text = mensajeError != "" ? mensajeError : "Error al guardar archivo.";
                }
            }
            catch (Exception ex)
            {
                lblMensajeArchivo.Text = "Error al guardar archivo: " + ex.Message;
            }
        }
        protected void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            string mensaje;
            string rutaArchivo = ProcesarArchivo(fileUpload.PostedFile, txtLinkArchivo.Text.Trim(), out mensaje);

            if (rutaArchivo == null)
            {
                lblMensajeArchivo.Text = mensaje;
                lblPaginas.Text = "";
                hdnRutaArchivoTemporal.Value = "";
                hdnUrlImagenSubida.Value = "";
                return;
            }

            string rutaPdfGenerado = null;
            int paginas = ContarPaginas(rutaArchivo, out string mensajePaginas, out rutaPdfGenerado);

            if (paginas <= 0)
            {
                lblMensajeArchivo.Text = mensajePaginas;
                lblPaginas.Text = "";
                hdnRutaArchivoTemporal.Value = "";
                hdnUrlImagenSubida.Value = "";
                return;
            }

            lblMensajeArchivo.Text = "Archivo cargado correctamente.";
            lblPaginas.Text = "Páginas detectadas: " + paginas;
            hdnPaginas.Value = paginas.ToString();

            hdnRutaArchivoTemporal.Value = rutaArchivo;

            string extension = System.IO.Path.GetExtension(rutaArchivo).ToLower();
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
            {

                hdnUrlImagenSubida.Value = ResolveUrl("~/ArchivosTemporales/") + System.IO.Path.GetFileName(rutaArchivo);
            }
            else
            {
                hdnUrlImagenSubida.Value = "";
            }


        }
        private string ProcesarArchivo(HttpPostedFile archivoSubido, string enlace, out string mensaje)
        {
            string rutaTemporal = Server.MapPath("~/ArchivosTemporales/");
            if (!Directory.Exists(rutaTemporal)) Directory.CreateDirectory(rutaTemporal);

            if (archivoSubido != null && archivoSubido.ContentLength > 0)
            {
                return GuardarArchivoDesdeDispositivo(archivoSubido, rutaTemporal, out mensaje);
            }
            else if (!string.IsNullOrWhiteSpace(enlace))
            {
                return DescargarArchivoDesdeEnlace(enlace, rutaTemporal, out mensaje);
            }
            else
            {
                mensaje = "Debe subir un archivo o ingresar un enlace.";
                return null;
            }
        }
        private int ContarPaginas(string rutaArchivo, out string mensaje, out string rutaPdfGenerado)
        {
            rutaPdfGenerado = null;

            try
            {
                string extension = System.IO.Path.GetExtension(rutaArchivo).ToLower();

                if (extension == ".pdf")
                {
                    using (PdfReader reader = new PdfReader(rutaArchivo))
                    {
                        mensaje = "";
                        rutaPdfGenerado = rutaArchivo;
                        return reader.NumberOfPages;
                    }
                }
                else if (extension == ".docx")
                {
                    rutaPdfGenerado = rutaArchivo + ".pdf";

                    try
                    {
                        Spire.Doc.Document documento = new Spire.Doc.Document();
                        documento.LoadFromFile(rutaArchivo);
                        documento.SaveToFile(rutaPdfGenerado, Spire.Doc.FileFormat.PDF);

                        using (PdfReader reader = new PdfReader(rutaPdfGenerado))
                        {
                            int paginas = reader.NumberOfPages;
                            mensaje = "";
                            return paginas;
                        }
                    }
                    catch (Exception ex)
                    {
                        mensaje = "Error al convertir DOCX a PDF: " + ex.Message;
                        return -1;
                    }
                }
                else if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {
                    mensaje = "";
                    return 1;
                }
                else
                {
                    mensaje = "Tipo de archivo no soportado para contar páginas.";
                    return -1;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al contar páginas: " + ex.Message;
                return -1;
            }
        }
        private string GuardarArchivoDesdeDispositivo(HttpPostedFile archivo, string rutaDestino, out string mensaje)
        {
            if (archivo.ContentLength > 5 * 1024 * 1024)
            {
                mensaje = "El archivo excede el límite de 5 MB.";
                return null;
            }

            string extension = System.IO.Path.GetExtension(archivo.FileName).ToLower();
            if (!EsExtensionPermitida(extension))
            {
                mensaje = "Tipo de archivo no permitido.";
                return null;
            }

            string rutaTemporal = Server.MapPath("~/ArchivosTemporales/");
            if (!Directory.Exists(rutaTemporal))
                Directory.CreateDirectory(rutaTemporal);

            string nombreUnico = Guid.NewGuid().ToString() + extension;
            string ruta = System.IO.Path.Combine(rutaTemporal, nombreUnico);
            archivo.SaveAs(ruta);

            mensaje = "Archivo subido correctamente.";
            return ruta;
        }
        private string DescargarArchivoDesdeEnlace(string enlace, string rutaDestino, out string mensaje)
        {
            if (!Uri.IsWellFormedUriString(enlace, UriKind.Absolute))
            {
                mensaje = "El enlace no es válido.";
                return null;
            }

            string urlFinal = enlace;

            if (enlace.Contains("docs.google.com/document"))
            {
                urlFinal = ConvertirEnlace(enlace);
                if (urlFinal == null)
                {
                    mensaje = "No se pudo convertir el enlace.";
                    return null;
                }
            }

            string extension = ObtenerExtensionDesdeUrl(urlFinal);
            if (!EsExtensionPermitida(extension))
            {
                mensaje = "Extensión del archivo no permitida.";
                return null;
            }

            bool esImagen = extension == ".jpg" || extension == ".jpeg" || extension == ".png";
            string carpetaDestino = esImagen ? Server.MapPath("~/Archivos/") : rutaDestino;

            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            string nombreTemp = Guid.NewGuid().ToString() + extension;
            string rutaFinal = System.IO.Path.Combine(carpetaDestino, nombreTemp);

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(urlFinal, rutaFinal);
                }

                mensaje = "Archivo descargado correctamente.";
                return rutaFinal;
            }
            catch (Exception ex)
            {
                mensaje = "Error al descargar archivo: " + ex.Message;
                return null;
            }
        }
        private bool EsExtensionPermitida(string ext)
        {
            return ext == ".pdf" || ext == ".docx" || ext == ".jpg" || ext == ".jpeg" || ext == ".png";
        }
        private string ConvertirEnlace(string url)
        {
            // Para documentos de Google Docs
            var match = Regex.Match(url, @"document/d/([a-zA-Z0-9_-]+)");
            if (match.Success)
            {
                string fileId = match.Groups[1].Value;
                return $"https://docs.google.com/document/d/{fileId}/export?format=pdf";
            }
            return null;
        }
        private string ObtenerExtensionDesdeUrl(string url)
        {
            string lower = url.ToLower();

            if (lower.Contains(".pdf")) return ".pdf";
            if (lower.Contains(".docx")) return ".docx";
            if (lower.Contains(".jpg") || lower.Contains(".jpeg")) return ".jpg";
            if (lower.Contains(".png")) return ".png";
            if (lower.Contains("export?format=pdf")) return ".pdf";
            return ".tmp";
        }
        private void LimpiarArchivosTemporales()
        {
            string rutaTemporal = Server.MapPath("~/ArchivosTemporales/");
            if (!Directory.Exists(rutaTemporal)) return;

            try
            {
                var archivos = Directory.GetFiles(rutaTemporal);
                foreach (var archivo in archivos)
                {
                    try
                    {
                        File.Delete(archivo);
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {
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
