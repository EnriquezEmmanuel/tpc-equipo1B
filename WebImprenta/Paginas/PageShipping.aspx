<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PageShipping.aspx.cs" Inherits="WebImprenta.Paginas.PageShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

                    <select id="Repartidos" name="Repartidos" class="campos-formulario">
                        <option value="">Mercado Libre</option>
                        <option value="">Reparto propio</option>
                    </select>

                    <asp:Button Text="Continuar"  OnClick="ContinuarEnvio_Click" CssClass="boton-formulario" runat="server" />

                    <!--------------- temporal de prueba ------------------>
                    <asp:Label Text="" ID="Usuario" runat="server" />
                    <!----------------------------------------------------->

                </div>
            </div>
        </div>
        <div class="tablon-claro contenedor-v alineacion-centrado-centrado">
            <div>
                <h3>Retirálo en nuestro local</h3>
                <p>Av. Marquez 123, San Isidro.</p>
            </div>

            <button class="boton-formulario">Continuar</button>

        </div>
    </section>
    <section id="ventana-modal">
        <asp:Label Text="" runat="server" ID="TextoModal"/>
			<div class="contenedor-h alineacion-centrado-final">
				<button class="boton-formulario" id="cancelar-modal">Aceptar</button>
			</div>
    </section>
</asp:Content>
