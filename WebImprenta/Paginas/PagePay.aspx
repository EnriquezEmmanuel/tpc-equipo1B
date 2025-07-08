<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PagePay.aspx.cs" Inherits="WebImprenta.Paginas.PagePay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="Secciones contenedor-v" id="detalle-pago">
        <h1 class="titular-h2 margen-left-2vw">Pago</h1>
        <div class="contenedor-v alineacion-centrado-centrado" id="contenedor-grilla">
            <h2>Finalizá el pago</h2>

            <div class="tablon-claro contenedor-v alineacion-centrado-centrado">
                <h2 class="txt-familia-Rto txt-bold txt-1em3 entero">Pedido #<span id="txt-numero-pedido">00432119</span>	|	
					
                    <span>julian@email.com</span>
                </h2>
                <div class="tablon-claro alineacion-around-inicio ">

                    <div class="">
                        <h3>Hoja</h3>
                        <ul>
                            <li>Tamaño:
                                <asp:Label ID="lblTamaño" runat="server" /></li>
                            <li>Tipo:
                                <asp:Label ID="lblTipoPapel" runat="server" /></li>
                            <li>Gramaje:
                                <asp:Label ID="lblGramaje" runat="server" /></li>
                        </ul>
                    </div>
                    <div class="">
                        <h3>Calidad</h3>
                        <ul>
                            <li>
                                <asp:Label ID="lblColor" runat="server" /></li>
                            <li>
                                <asp:Label ID="lblCalidad" runat="server" /></li>
                            <li>
                                <asp:Label ID="lblDobleCara" runat="server" /></li>
                        </ul>
                    </div>
                    <div class="">
                        <h3>Detalles de<br />
                            impresión</h3>
                        <ul>
                            <li>Copias por hoja:
                                <asp:Label ID="lblCopiasPorHoja" runat="server" /></li>
                            <li>Cantidad de copias:
                                <asp:Label ID="lblNumeroCopias" runat="server" /></li>
                            <li>Margen (2mm):
                                <asp:Label ID="lblMargen" runat="server" /></li>
                        </ul>
                    </div>

                </div>


                <div class="contenedor-h entero alineacion-around-center">
                    <div class="contenedor-v alineacion-centrado-inicio">
                        <h3></h3>
                        
                    </div>
                    <div class="contenedor-v alineacion-centrado-final">
                        <h3>Impresión</h3>
                        <p id="lblPrecioImpresion" runat="server" class="precio-impresion" />
                    </div>
                    <div class="contenedor-v alineacion-centrado-final">
                        <h3>Envio</h3>
                        <p id="lblPrecioEnvio" runat="server" />

                    </div>
                    <div class="contenedor-v alineacion-centrado-final">
                        <h3>PreTotal</h3>
                        <p id="lblPreTotal" runat="server" />
                    </div>
                </div>
                <div>
                    <button class="boton-formulario">Anular pedido</button>
                    <button class="boton-formulario">Modificar pedido</button>
                    <button class="boton-formulario">Pagar</button>
                </div>
                <div>
                    <p class="txt-color-resaltado-1 txt-bold">*Las señas no tienen devoluciones, revisá el pedido antes de continuar</p>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
