<%@ Page Title="" Language="C#" MasterPageFile="~/MasterOperador.Master" AutoEventWireup="true" CodeBehind="PageRecepcion.aspx.cs" Inherits="WebImprenta.Paginas.PageRecepcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/CompotamientoGenerico.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="Secciones contenedor-v" id="Lista-Pedidos">
		<h2 class="titular-h2 margen-left-2vw">Lista de pedidos</h2>
		<div class="contenedor-v alineacion-centrado-centrado" id="contenedor-grilla">		

		<!----------------------- Esto es temporal hasta que creemos las sessiones de usuario ----------------------->

            <asp:Label Text="4" runat="server" Visible="false" ID="ReferenciaIdUsuario" />	<!-- Usuario Lucas en mi caso -->

		<!----------------------------------------------------------------------------------------------------------->

			<asp:GridView ID="grillaPedidos" runat="server" AutoGenerateColumns="False" 
				CssClass="grilla-fila margen-2em " HeaderStyle-CssClass="grilla-cabecera"  
				RowStyle-CssClass="grilla-fila alineacion-centrado-centrado" ColumnStyle-CssClass="grilla-columna"
				GridLines="None" OnSelectedIndexChanged="grillaPedidos_SelectedIndexChanged" DataKeyNames="IdPedido">
				<Columns >
					
					<asp:CommandField HeaderText="Selección" ShowSelectButton="true" SelectText="--&gt" ItemStyle-CssClass="visible-sobre"/>
					<asp:BoundField HeaderText="Nombre" DataField="NombreUsuario" />
					<asp:BoundField HeaderText="Nro Pedido" DataField="IdPedido" />
					<asp:BoundField HeaderText="Fecha" DataField="Fecha" />
					<asp:BoundField HeaderText="E-mail" DataField="Email" />
					<asp:BoundField HeaderText="Estado" DataField="Estado" />
				</Columns>

			</asp:GridView>
		</div>	
		<div class="contenedor-h alineacion-centrado-centrado margen-2em">
			<button type="button" class="boton-formulario" id="btn-abrir-modal">Actualizar Estado</button>
		</div>
	</section>

<!---------------------------------------------------------------------------------------------------------------------->
	<section id="Pedido">
		<div class="tablon-claro">
			<h2 class="txt-familia-Rto txt-bold txt-1em3 entero">
				Pedido #<span id="txt-numero-pedido"><asp:Label Text="" id="lblnroPedido" runat="server" /></span>	|	
				<span><asp:Label Text="" id="lblNombreU" runat="server" /></span>	|	
				<span id="txt-estado-pedido" class="txt-normal txt-familia-Rto-Slab"><asp:Label Text="" id="lblEstadoPedido" runat="server" /></span>
			</h2>
			<div class="cuarto">
				<h3>Hoja</h3>
					<ul>
						<li class="margen-bottom-0em3">Tamaño: <asp:Label Text="" id="lblTamanio" runat="server" /></li>
						<li class="margen-bottom-0em3">Tipo: <asp:Label Text="" id="lblTipo" runat="server" /></li>
						<li class="margen-bottom-0em3">Gramaje: <asp:Label Text="" id="lblGramaje" runat="server" /></li>
					</ul>
			</div>
			<div class="cuarto">
				<h3>Calidad</h3>
					<ul>
						<li class="margen-bottom-0em3"><asp:Label Text="" id="lblColor" runat="server" /></li>
						<li class="margen-bottom-0em3"><asp:Label Text="" id="lblCalidad" runat="server" /></li>
					</ul>
			</div><div class="cuarto">
				<h3>Detalles de impresión</h3>
					<ul>
						<li class="margen-bottom-0em3">Copias por hoja: <asp:Label Text="" id="lblCopasXhoja" runat="server" /></li>
						<li class="margen-bottom-0em3">Cantidad de copias: <asp:Label Text="" id="lblCantidad" runat="server" /></li>
						<li class="margen-bottom-0em3">Margen (2mm): <asp:Label Text="" id="lblMargen" runat="server" /></li>
					</ul>
			</div>
			<div class="cuarto contenedor-v alineacion-inicio-centrado">
				<h3>Precio</h3>
				<ul><li>$1400</li></ul>
				<h3>Envío</h3>
				<ul><li>$1000</li></ul>
			</div>
			
		</div>
	</section>
	<section id="Mensajes">
		<h2 class="titular-h2 margen-left-2vw">Mensajes</h2>
		<div class="contenedor-v">
			
			<div class="tablon-oscuro medio-v contenedor-v" runat="server" id="ContenedorMensajes">
			</div>

			<div class="tablon-claro margen-bottom- alineacion-between-center contenedor-h">
				
				<asp:TextBox ID="MensajeAenviar" Rows="2" CssClass="textarea-transparente texto-noresize tercios-2" runat="server" TextMode="MultiLine"></asp:TextBox>
				<input type="hidden" value="" id="ReferenciaPedido" runat="server" /> 				
				<asp:Button ID="EnviarMensaje" CssClass="boton-formulario-claro " runat="server" Text="Enviar" OnClick="EnviarMensaje_Click" />
				
			</div>
		</div>
		
	</section>
	
	
	<section id="ventana-modal">		
		<asp:Label ID="TextoModal" runat="server" Text="Esto es un texto modal:"></asp:Label><br />
		<asp:DropDownList ID="ddlListaEstados" class="select-oscuro " runat="server"></asp:DropDownList>

		<div class="contenedor-h alineacion-centrado-final">
			<asp:Button ID="btnAceptarModal" OnClick="btnAceptarModal_Click" class="boton-formulario" runat="server" Text="Modificar" />
			<button class="boton-formulario" id="btn-cerrar-modal">Cancelar</button>
		</div>
	</section>
</asp:Content>
