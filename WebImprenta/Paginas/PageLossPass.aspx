<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PageLossPass.aspx.cs" Inherits="WebImprenta.Paginas.PageLossPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Content/estilos-propios.css") %>"/>
	<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Content/estilos-prefijados-propios.css") %>"/>
	<script type="text/javascript" src="../Scripts/CompotamientoGenerico.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<section class="Secciones contenedor-v" >
			<h2 >Recuperación de contraseña</h2>
			
			<div class="contenedor-v alineacion-centrado-centrado margen-2em">

                <h3>Indicanos el mail con el cual estás registrado, para recuperar tu contraseña.</h3>
				<div class="contenedor-v alineacion-centrado-centrado margen-2em">

					<label class="margen-1em">E-mail: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
					<asp:TextBox runat="server" ID="tbxEmail" Columns="50"/>
                    <asp:Button CssClass="boton-formulario margen-top-2vw" ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click"/>

                    <asp:Label ID="lblVerifCambioClave" Text="" runat="server" />
                </div>
			</div>
		</section>
        <section id="ventana-modal">		
			<asp:Label Text="" runat="server" ID="TextoModal"/>
			<div class="contenedor-h alineacion-centrado-final">
				<%--<button class="boton-formulario" id="aceptar-modal">Aceptar</button>--%>
				<button class="boton-formulario" id="cancelar-modal">Cancelar</button>
			</div>
		</section>
</asp:Content>
