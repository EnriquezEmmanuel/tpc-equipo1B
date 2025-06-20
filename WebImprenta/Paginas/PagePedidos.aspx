<%@ Page Title="" Language="C#" MasterPageFile="~/MasterOperador.Master" AutoEventWireup="true" CodeBehind="PagePedidos.aspx.cs" Inherits="WebImprenta.gestion_catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript" src="../Scripts/CompotamientoGenerico.js"></script>
	<style>
		#TextoModal{
			visibility: hidden;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Pedidos</h1>
		<div class="contenedor-v alineacion-centrado-centrado">	
			<%--<select name="Fecha[]" class="select-oscuro " id="select-encuad">
				
				<asp:Repeater ID="FechaPedidos" runat="server">
					<ItemTemplate>
						<option value="<%contFecha++; %>"><%# Eval("Fecha") %></option>
					</ItemTemplate>
				</asp:Repeater>
			</select><br>--%>

			
			<table>
				<asp:DataList ID="DataList1" runat="server"></asp:DataList>
				<tr>
					<td class="cabecera">Pedido</td>
					<td class="cabecera">E-mail</td>
					<td class="cabecera">Fecha</td>
					<td class="cabecera">Hoja</td>
					<td class="cabecera">Color</td>
					<td class="cabecera">Calidad</td>
					<td class="cabecera">Copias por Hoja</td>
					<td class="cabecera">Margen</td>
					<td class="cabecera">Copias </td>
					<td class="cabecera">Estado </td>
				</tr>
			<asp:Repeater ID="grillaPedidos"  runat="server">
				<ItemTemplate>		
					<%--
						Esto debe tener un try catch
					--%>
						<tr class="filas-grilla">
							<td><%# Eval("IdPedido") %></td>
							<td><%# Eval("Email") %></td>
							<td><%# Eval("Fecha") %></td>
							<td><%# Eval("Hoja") %></td>
							<td><%# Eval("Color") %></td>
							<td><%# Eval("Calidad") %></td>
							<td><%# Eval("CopiaPorHoja") %></td>
							<td><%# Eval("Margenes") %></td>
							<td><%# Eval("Copias") %></td>
							<td><%# Eval("Estado") %></td>

						</tr>
				</ItemTemplate>
			</asp:Repeater>

			</table>

<!------------------------ botonera ------------------------>
			<div class="contenedor-h alineacion-centrado-centrado">
				<p>Número de pedido: </p>

				<asp:DropDownList ID="ddlPedido" class="select-oscuro " runat="server"></asp:DropDownList>	
				<button type="button" class="boton-formulario" id="btn-abrir-modal">Actualizar Estado</button>
				<%-- %>asp:Button ID="btnSeleccionarFecha" class="boton-formulario" runat="server" onclick="btnSeleccionarFecha_Click" Text="Seleccionar pedido" /--%>
			</div>

			<div class="entero botonera" >
				<!--button type="button" class="boton-formulario" id="btn-actualizar" >Actualizar Estado</button-->
				
				<!--button type="button" class="boton-formulario boton-bloqueado" id="btn-actualizar-cancelar" disabled>Cancelar</button><br><br-->
				<%--<asp:Button ID="btnActualizarAceptar" runat="server" Text="Button" class="boton-formulario boton-bloqueado"/>  OnClientClick="return registrarClick();" --%>
			</div>
			
		</div>
	<section id="ventana-modal">
		<!--p id="parrafo-modal">Número de pedido: </p-->
		
		<asp:Label ID="TextoModal" runat="server" Text="Estados: "></asp:Label><br />
		
		<asp:DropDownList ID="ddlListaEstados" class="select-oscuro " runat="server"></asp:DropDownList>

		<div class="contenedor-h alineacion-centrado-final">
			<!--button class="boton-formulario" id="aceptar-modal">Aceptar</button-->
			<asp:Button ID="btnAceptarModal" OnClick="btnAceptarModal_Click" class="boton-formulario" runat="server" Text="Modificar" />
			<button class="boton-formulario" id="btn-cerrar-modal">Cancelar</button>
		</div>
	</section>

</asp:Content>
