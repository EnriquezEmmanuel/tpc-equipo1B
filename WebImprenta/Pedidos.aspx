<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="WebImprenta.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/CompotamientoGenerico.js"></script>
    <style>
        .ms-offset-6-5 {
            margin-left: 52%;
        }

        .preview-division {
            position: absolute;
            border: 1px dashed #6c757d;
            background: rgba(220, 220, 220, 0.2);
            display: flex;
            justify-content: center;
            align-items: center;
            font-size: 10px;
            color: #333;
            box-sizing: border-box;
        }

        .accordion-body,
        .container,
        .accordion-item,
        .card,
        .form-control,
        .bg-white,
        .bg-light {
            background-color: transparent !important;
            color: var(--casiBlanco);
        }

        .form-control {
            background-color: #f1f1f1 !important;
            color: #000;
        }
    </style>
    <script>
        function extraerNumero(texto) {
            const match = texto.replace(",", ".").match(/[\d.]+/);
            return match ? parseFloat(match[0]) : 0;
        }
        function calcularSubtotal() {
            const txtCopias = document.getElementById('<%= txtNumeroCopias.ClientID %>');
            const lblPrecioHoja = document.getElementById('<%= lblPrecioHoja.ClientID %>');
            const lblPrecioCalidad = document.getElementById('<%= lblPrecioCalidad.ClientID %>');
            const lblPrecioDetalles = document.getElementById('<%= lblPrecioDetalles.ClientID %>');
            const lblSubtotal = document.getElementById('<%= lblSubtotal.ClientID %>');
            const hdnPaginas = document.getElementById('<%= hdnPaginas.ClientID %>');
            const hdnSubtotal = document.getElementById('<%= hdnSubtotal.ClientID %>');

            if (!txtCopias || !lblPrecioHoja || !lblPrecioCalidad || !lblPrecioDetalles || !lblSubtotal || !hdnPaginas || !hdnSubtotal) {
                return;
            }

            const precioHoja = extraerNumero(lblPrecioHoja.textContent);
            const precioCalidad = extraerNumero(lblPrecioCalidad.textContent);
            const copias = parseInt(txtCopias.value) || 1;
            const paginas = parseInt(hdnPaginas.value) || 1;

            const precioDetalles = (precioHoja + precioCalidad) * copias;
            const subtotal = precioDetalles * paginas;

            lblPrecioDetalles.textContent = "$" + precioDetalles.toFixed(2);
            lblSubtotal.textContent = "$" + subtotal.toFixed(2);
            hdnSubtotal.value = subtotal.toFixed(2);
        }

        function inicializarEventosSubtotal() {
            const txtCopias = document.getElementById('<%= txtNumeroCopias.ClientID %>');

        const ddlIds = [
            '<%= ddlTamaño.ClientID %>',
            '<%= ddlTipoPapel.ClientID %>',
            '<%= ddlGramaje.ClientID %>',
            '<%= ddlColor.ClientID %>',
            '<%= ddlCalidad.ClientID %>',
                '<%= ddlDobleCara.ClientID %>'
            ];

            ddlIds.forEach(id => {
                const el = document.getElementById(id);
                if (el) {
                    el.removeEventListener("change", calcularSubtotal);
                    el.addEventListener("change", calcularSubtotal);
                }
            });

            if (txtCopias) {
                txtCopias.removeEventListener("input", calcularSubtotal);
                txtCopias.addEventListener("input", calcularSubtotal);
            }

            calcularSubtotal();
        }

        function actualizarVistaPrevia() {
            const copiasInput = document.getElementById('inputCopiasPorHoja');
            const copiasPorHoja = parseInt(copiasInput?.value) || 1;

            const tamañoSelect = document.querySelector('[id$=ddlTamaño]');
            const posicionSelect = document.querySelector('[id$=ddlPosicion]');
            const margenSelect = document.querySelector('[id$=ddlMargen]');

            if (!tamañoSelect || !posicionSelect || !margenSelect) return;

            const tamaño = tamañoSelect.value;
            const posicion = posicionSelect.value;
            const margen = margenSelect.value;

            const previewWrapper = document.getElementById('previewWrapper');
            const previewContainer = document.getElementById('previewContainer');
            previewContainer.innerHTML = '';

            if (!tamaño) {
                previewWrapper.style.display = 'none';
                previewWrapper.className = '';
                return;
            }

            previewWrapper.style.display = 'block';
            previewWrapper.className = 'border p-3 d-inline-block bg-white shadow-sm';

            let width = 210, height = 297, labelTamaño = "A4";
            switch (tamaño.toLowerCase()) {
                case "a3": width = 297; height = 420; labelTamaño = "A3"; break;
                case "a4": width = 210; height = 297; labelTamaño = "A4"; break;
                case "a5": width = 148; height = 210; labelTamaño = "A5"; break;
                case "oficio": width = 216; height = 330; labelTamaño = "Oficio"; break;
                case "carta": width = 216; height = 279; labelTamaño = "Carta"; break;
            }

            if (posicion === "Horizontal") [width, height] = [height, width];

            const escala = 1;
            const hojaWidth = width * escala;
            const hojaHeight = height * escala;

            const hoja = document.createElement('div');
            hoja.style.width = hojaWidth + 'px';
            hoja.style.height = hojaHeight + 'px';
            hoja.style.border = '2px solid #000';
            hoja.style.position = 'relative';
            hoja.style.backgroundColor = '#fff';
            hoja.style.boxSizing = 'border-box';
            hoja.style.overflow = 'hidden';

            const etiqueta = document.createElement('div');
            etiqueta.innerText = `${labelTamaño} - ${width}x${height} mm`;
            etiqueta.style.position = 'absolute';
            etiqueta.style.top = '50%';
            etiqueta.style.left = '50%';
            etiqueta.style.transform = 'translate(-50%, -50%)';
            etiqueta.style.fontSize = '12px';
            etiqueta.style.color = '#666';
            etiqueta.style.pointerEvents = 'none';
            hoja.appendChild(etiqueta);

            if (margen === "true") {
                const margenDiv = document.createElement('div');
                margenDiv.style.position = 'absolute';
                margenDiv.style.top = '2mm';
                margenDiv.style.left = '2mm';
                margenDiv.style.right = '2mm';
                margenDiv.style.bottom = '2mm';
                margenDiv.style.border = '1px dotted #bbb';
                hoja.appendChild(margenDiv);
            }

            let areaX = 0, areaY = 0, areaWidth = hojaWidth, areaHeight = hojaHeight;

            if (margen === "true") {
                const margenMM = 2;
                const mmToPx = 3.78;
                const margenPx = margenMM * mmToPx;

                areaX = margenPx;
                areaY = margenPx;
                areaWidth -= 2 * margenPx;
                areaHeight -= 2 * margenPx;
            }

            const columnas = Math.ceil(Math.sqrt(copiasPorHoja));
            const filas = Math.ceil(copiasPorHoja / columnas);

            const urlImagenSubida = document.querySelector('[id$=hdnUrlImagenSubida]')?.value;

            for (let i = 0; i < copiasPorHoja; i++) {
                const copia = document.createElement('div');
                copia.className = 'preview-division';
                copia.style.width = (areaWidth / columnas - 8) + 'px';
                copia.style.height = (areaHeight / filas - 8) + 'px';

                const col = i % columnas;
                const row = Math.floor(i / columnas);
                copia.style.left = (areaX + col * (areaWidth / columnas) + 4) + 'px';
                copia.style.top = (areaY + row * (areaHeight / filas) + 4) + 'px';

                if (urlImagenSubida) {
                    const img = document.createElement('img');
                    img.src = urlImagenSubida;
                    img.style.width = '100%';
                    img.style.height = '100%';
                    img.style.objectFit = 'contain';
                    copia.appendChild(img);
                }

                hoja.appendChild(copia);
            }

            previewContainer.appendChild(hoja);
        }

        function inicializarEventosVistaPrevia() {
            const root = document;

            root.addEventListener('change', function (e) {
                if (
                    e.target.matches('[id$=ddlTamaño]') ||
                    e.target.matches('[id$=ddlPosicion]') ||
                    e.target.matches('[id$=ddlMargen]')
                ) {
                    actualizarVistaPrevia();
                }
            });

            root.addEventListener('input', function (e) {
                if (e.target.id === 'inputCopiasPorHoja') {
                    actualizarVistaPrevia();
                }
            });

            actualizarVistaPrevia();
        }

        function validarFormulario() {
            const form = document.getElementById('form1');
            form.classList.add('was-validated');
            return form.checkValidity();
        }

        document.addEventListener("DOMContentLoaded", function () {
            inicializarEventosVistaPrevia();
            inicializarEventosSubtotal();
        });

        if (typeof Sys !== 'undefined') {
            Sys.Application.add_load(function () {
                inicializarEventosVistaPrevia();
                inicializarEventosSubtotal();
            });
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:HiddenField ID="hdnRutaArchivoTemporal" runat="server" EnableViewState="true" />
    <asp:HiddenField ID="HiddenField1" runat="server" EnableViewState="true" />
    <asp:HiddenField ID="hdnUrlImagenSubida" runat="server" />
    <asp:HiddenField ID="hdnSubtotal" runat="server" />
    <asp:HiddenField ID="hdnPaginas" runat="server" />

   

    <div class="accordion" id="accordionPedidos">
        <div class="accordion-item border-0">
            <h2 class="accordion-header" id="headingFormulario">
                <button class="accordion-button bg-primary text-white fs-5" type="button"
                    data-bs-toggle="collapse" data-bs-target="#collapseFormulario"
                    aria-expanded="true" aria-controls="collapseFormulario">
                    ✏️ Realizá tu pedido
                </button>
            </h2>
            <div id="collapseFormulario" class="accordion-collapse collapse show"
                aria-labelledby="headingFormulario" data-bs-parent="#accordionPedidos">
                <div class="accordion-body px-0">

                    <div class="container mb-4">
                        <div class="row mt-5 mb-2">
                            <div class="col-md-12">
                                <h3 class="mb-0">Subí tus archivos o indicanos dirección donde se alojan</h3>
                            </div>
                        </div>
                        <div class="row mb-5 ms-5">
                            <div class="col-md-5">
                                <label for="fileUpload" class="form-label">Dispositivo <span style="color: red;">(hasta 5MB)</span></label>
                                <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control" accept=".pdf,.docx,.jpg,.jpeg,.png" />
                            </div>
                            <div class="col-md-1 d-flex justify-content-center">
                                <label class="fw-bold" style="margin-top: 40px;">Ó</label>
                            </div>
                            <div class="col-md-5">
                                <label for="txtLinkArchivo" class="form-label">Dirección </label>
                                <asp:TextBox ID="txtLinkArchivo" runat="server" CssClass="form-control" placeholder="" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 ms-5">
                                <asp:Button ID="btnSubirArchivo" runat="server" CssClass="btn btn-secondary w-100" Text="Subir archivo" OnClick="btnSubirArchivo_Click" CausesValidation="false" UseSubmitBehavior="false" />
                                <asp:Image ID="imgPreview" runat="server" CssClass="mt-3" Style="max-width: 200px;" Visible="false" />
                                <asp:Label ID="lblNombreArchivo" runat="server" CssClass="mt-2 d-block fw-bold" ForeColor="Black" />
                                <asp:Label ID="lblMensajeArchivo" runat="server" CssClass="mt-3 d-block fw-bold" ForeColor="Red" />
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblPaginas" runat="server" CssClass="fw-bold mt-2 d-block" ForeColor="DarkGreen" />
                            </div>
                        </div>
                    </div>
                    <div class="container py-5">
                        <asp:UpdatePanel ID="updPanelHoja" runat="server">
                            <ContentTemplate>

                                <!-- BLOQUE HOJA -->
                                <div class="row align-items-end mb-2">
                                    <div class="col-md-2">
                                        <h2 class="mb-2">Hoja</h2>
                                    </div>
                                    <div class="col-md-2 ms-offset-6-5">
                                        <h2 class="mb-2 text-end">Precio</h2>
                                    </div>
                                </div>
                                <div class="row mb-4">
                                    <div class="col-md-3 ms-5">
                                        <label for="ddlTamaño" class="form-label">Tamaño</label>
                                        <asp:DropDownList ID="ddlTamaño" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ActualizarPrecio" AppendDataBoundItems="true" required="required">
                                            <asp:ListItem Text="" Value="" Disabled="true" Selected="true" />
                                        </asp:DropDownList>
                                        <div class="invalid-feedback">Seleccione un tamaño.</div>
                                    </div>
                                    <div class="col-md-3">
                                        <label for="ddlTipoPapel" class="form-label">Tipo de Papel</label>
                                        <asp:DropDownList ID="ddlTipoPapel" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ActualizarPrecio" AppendDataBoundItems="true" required="required">
                                            <asp:ListItem Text="" Value="" Disabled="true" Selected="true" />
                                        </asp:DropDownList>
                                        <div class="invalid-feedback">Seleccione un Tipo de Papel.</div>
                                    </div>
                                    <div class="col-md-2">
                                        <label for="ddlGramaje" class="form-label">Gramaje</label>
                                        <asp:DropDownList ID="ddlGramaje" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ActualizarPrecio" AppendDataBoundItems="true" required="required">
                                            <asp:ListItem Text="" Value="" Disabled="true" Selected="true" />
                                        </asp:DropDownList>
                                        <div class="invalid-feedback">Seleccione un gramaje.</div>
                                    </div>
                                    <div class="col-md-1 offset-md-1 text-end align-self-end">
                                        <asp:Label ID="lblPrecioHoja" runat="server" CssClass="form-control fw-bold text-end" Text=" $" />

                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>


                        <!-- BLOQUE CALIDAD -->
                        <asp:UpdatePanel ID="updPanelCalidad" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-12">
                                        <h2>Calidad</h2>
                                    </div>
                                </div>
                                <div class="row mb-4">

                                    <div class="col-md-3 ms-5">
                                        <label class="form-label">Color</label>
                                        <asp:DropDownList ID="ddlColor" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ActualizarPrecioCalidad" AppendDataBoundItems="true" required="required">
                                            <asp:ListItem Text="" Value="" Disabled="true" Selected="true" />
                                            <asp:ListItem Text="Blanco y negro" Value="Blanco y negro" />
                                            <asp:ListItem Text="Color" Value="Color" />
                                        </asp:DropDownList>
                                        <div class="invalid-feedback">Seleccione un color.</div>
                                    </div>

                                    <div class="col-md-3">
                                        <label class="form-label">Calidad</label>
                                        <asp:DropDownList ID="ddlCalidad" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ActualizarPrecioCalidad" AppendDataBoundItems="true" required="required">
                                            <asp:ListItem Text="" Value="" Disabled="true" Selected="true" />
                                            <asp:ListItem Text="Rápida" Value="Rápida" />
                                            <asp:ListItem Text="Óptima" Value="Óptima" />
                                            <asp:ListItem Text="Alta" Value="Alta" />
                                        </asp:DropDownList>
                                        <div class="invalid-feedback">Seleccione una calidad.</div>
                                    </div>

                                    <div class="col-md-2">
                                        <label class="form-label">Doble cara</label>
                                        <asp:DropDownList ID="ddlDobleCara" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ActualizarPrecioCalidad">
                                            <asp:ListItem Text="No" Value="false" />
                                            <asp:ListItem Text="Sí" Value="true" />
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-1 offset-md-1 d-flex align-items-end">
                                        <asp:Label ID="lblPrecioCalidad" runat="server" CssClass="form-control bg-light fw-bold text-end" Text="$" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <!-- BLOQUE DETALLES DE IMPRESIÓN -->
                        <asp:UpdatePanel ID="updPanelDetalles" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-12">
                                        <h2>Detalles de impresión</h2>
                                    </div>
                                </div>
                                <div class="row mb-4">

                                    <div class="col-md-2 ms-5">
                                        <label class="form-label">Copias por hoja</label>
                                        <input type="number" id="inputCopiasPorHoja" class="form-control" min="1" step="1" value="1" required />
                                        <div class="invalid-feedback">Ingrese una cantidad válida.</div>
                                    </div>

                                    <div class="col-md-2 ">
                                        <label class="form-label">Número de copias</label>
                                        <asp:TextBox ID="txtNumeroCopias" runat="server" AutoPostBack="true" OnTextChanged="ActualizarPrecio" CssClass="form-control" Text="1" />
                                        <div class="invalid-feedback">Ingrese el número de copias.</div>
                                    </div>

                                    <div class="col-md-2">
                                        <label class="form-label">Margen (2mm)</label>
                                        <asp:DropDownList ID="ddlMargen" runat="server" CssClass="form-select">
                                            <asp:ListItem Text="No" Value="false" />
                                            <asp:ListItem Text="Sí" Value="true" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label">Posición</label>
                                        <asp:DropDownList ID="ddlPosicion" runat="server" CssClass="form-select">
                                            <asp:ListItem Text="Vertical" Value="Vertical" />
                                            <asp:ListItem Text="Horizontal" Value="Horizontal" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-1 offset-md-1 text-end align-self-end">
                                        <asp:Label ID="lblPrecioDetalles" runat="server" CssClass="form-control bg-light fw-bold text-end" Text=" $" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <%-- Vista Previa --%>
                        <div class="row mb-4">
                            <div class="col-md-10 offset-md-1">
                                <h4 class="mb-3">Vista previa de impresión</h4>
                                <div id="previewWrapper" style="display: none;">
                                    <div id="previewContainer" style="position: relative;"></div>
                                </div>
                            </div>
                        </div>
                        <div class="row mt-5 align-items-end">
                            <div class="col-md-5 ms-5">
                                <asp:Button Text="CONTINUAR CON EL PEDIDO" ID="btnAceptar" runat="server"
                                    CssClass="btn btn-primary btn-lg w-100"
                                    OnClientClick="return validarFormulario();" OnClick="btnAceptar_Click" />
                            </div>

                            <div class="col-md-2 offset-md-1 text-end">
                                <h3 class="mb-2">Subtotal</h3>
                            </div>

                            <div class="col-md-2 text-end">
                                <asp:Label ID="lblSubtotal" runat="server" CssClass="form-control bg-light fw-bold text-end" Text=" $" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- PANEL 2: Tus pedidos -->
        <div class="accordion-item border-0 mt-3">
            <h2 class="accordion-header" id="headingPedidos">
                <button class="accordion-button collapsed bg-primary text-white fs-5" type="button"
                    data-bs-toggle="collapse" data-bs-target="#collapsePedidos"
                    aria-expanded="false" aria-controls="collapsePedidos">
                    📦 Tus pedidos
                </button>
            </h2>
            <div id="collapsePedidos" class="accordion-collapse collapse"
                aria-labelledby="headingPedidos" data-bs-parent="#accordionPedidos">
                <div class="accordion-body">
                    <div class="container">
                        <%-- lista de pedidos --%>

                        <asp:UpdatePanel ID="updPanelPedidosRealizados" runat="server">

                            <ContentTemplate>

        <!----------------- Esto es temporal hasta que tengamos los usuarios ----------------->
    
                                <asp:Label Text="Usuario" runat="server" />
                                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                                <asp:Label Text="Clave" runat="server" />
                                <asp:TextBox ID="tbPass" runat="server" TextMode="Password" />

                                <asp:Button ID="btnValidar" runat="server" Text="Validar" OnClick="btnValidar_Click" CausesValidation="false"/>

                                <%--<asp:Label Text="1234" runat="server" ID="txtValidacion"/>--%>


                                <div class="tablon-claro" runat="server" id="ContenedorPedidos">
			                    
                                </div>
         <!----------------------------------------------------------------------------------->
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <section id="ventana-modal">		
		<asp:Label ID="TextoModal" runat="server" Text="Esto es un texto modal:"></asp:Label><br />

		<div class="contenedor-h alineacion-centrado-final">
			<%--<asp:Button ID="btnAceptarModal" OnClick="btnAceptarModal_Click" class="boton-formulario" runat="server" Text="Modificar" />--%>
			<button class="boton-formulario" id="btn-cerrar-modal">Cerrar</button>  <!--Cancelar</button>-->
		</div>
	</section>

</asp:Content>
