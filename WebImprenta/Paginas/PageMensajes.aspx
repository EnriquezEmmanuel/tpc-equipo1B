<%@ Page Title="" Language="C#" MasterPageFile="~/MasterOperador.Master" AutoEventWireup="true" CodeBehind="PageMensajes.aspx.cs" Inherits="WebImprenta.Paginas.Mensajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="">
			<h1 class="titular-h1">Mensajes</h1>
			<h2 class="titular-h2 margen-left-5vw">Usuario</h2>
			<select name="Usuarios[]" size="1" class="campos-formulario margen-left-5vw" multiple>
				<option value="1">Joaquin@gmail.com, Joaquin</option>
				<option value="2">Daniela@gmail.com, Daniela</option>
				<option value="2">Anahí@gmail.com, Anahí</option>
			</select>

			<div class="contenedor-v tablon-oscuro medio-v">
				
				<p class="margen-bottom-1vw txt-oblique">
					<span class="txt-bold-oblique">Joaquin</span> <span class="txt-oblique">12/06/2025</span><br>
					Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
					tempor incididunt ut labore et dolore magna aliqua. 
				</p>
				<p class="margen-bottom-1vw txt-oblique">
					<span class="txt-bold-oblique">Lucas (Operador)</span> <span class="txt-oblique">12/06/2025</span><br>
					Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
					tempor incididunt ut labore et dolore magna aliqua. 
				</p>
			</div>
			<textarea cols="100" rows="2" class="tablon-claro margen-bottom-3vw"></textarea>
			<button type="button" class="boton-formulario margen-bottom-3vw" id="btn-enviar">Enviar</button>
			<button type="button" class="boton-formulario margen-bottom-3vw" id="btn-borrar-campo">Borrar campo</button>
		</div>	
</asp:Content>
