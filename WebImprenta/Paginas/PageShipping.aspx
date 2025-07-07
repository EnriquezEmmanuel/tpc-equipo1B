<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PageShipping.aspx.cs" Inherits="WebImprenta.Paginas.PageShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/CompotamientoGenerico.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="Secciones contenedor-v" id="Envios">

        <h1 class="titular-h2 margen-left-2vw">Envios</h1>
        <div class="contenedor-v alineacion-centrado-centrado" id="contenedor-tablones">

            <h2>Elegí la forma de entrega</h2>

            <div class="tablon-claro contenedor-v alineacion-centrado-centrado">

                <div class="contenedor-v alineacion-centrado-centrado">
                    <h3>Envío a domicilio</h3>

                    <label>Elegí un domicilio: </label>
                    <asp:DropDownList ID="ddlDomicilios" CssClass="campos-formulario" runat="server" ></asp:DropDownList>

                    <label>Elegí al repartidor: </label>
                    <asp:DropDownList ID="ddlRepartidor" CssClass="campos-formulario" runat="server"></asp:DropDownList>

                    <asp:Button Text="Continuar"  OnClick="ContinuarEnvio_Click" CssClass="boton-formulario" runat="server" />

                    <!--------------- temporal de prueba ------------------>
                    <asp:Label Text="" ID="IdDireccion" runat="server" />
                    <asp:Label Text="" ID="MetodoEnvio" runat="server" />
                    <!----------------------------------------------------->

                </div>
            </div>
        </div>
        <div class="contenedor-v alineacion-centrado-centrado entero">
            <div class="tablon-claro contenedor-v alineacion-centrado-centrado">
                <div>
                    <h3>Retirálo en nuestro local</h3>
                    <asp:Label Text="Av. Marquez 123, San Isidro." ID="DireccionLocal" runat="server" />
                    
                </div>

                <asp:Button Text="Continuar" OnClick="ContinuarSinEnvio_Click" CssClass="boton-formulario" runat="server" />

            </div>
        </div>
    </section>
    <section id="ventana-modal">
        <asp:Label Text="" runat="server" ID="TextoModal"/>
			<div class="contenedor-h alineacion-centrado-final">
				<button class="boton-formulario" id="cancelar-modal">Aceptar</button>
			</div>
    </section>
</asp:Content>
