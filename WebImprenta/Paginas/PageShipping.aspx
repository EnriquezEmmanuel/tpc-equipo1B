<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PageShipping.aspx.cs" Inherits="WebImprenta.Paginas.PageShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="Secciones contenedor-v" id="Envios">
		<h1 class="titular-h2 margen-left-2vw">Envios</h1>
		<div class="contenedor-v alineacion-centrado-centrado" id="contenedor-grilla">

			<h2>Elegí la forma de entrega</h2>

		<div class="tablon-claro contenedor-v alineacion-centrado-centrado">
			
			<div class="contenedor-v alineacion-centrado-centrado">
				<h3>Envío a domicilio</h3>
				<label>Elegí un domicilio: </label>
				<select id="Domicilios" name="Domicilios" class="campos-formulario">
				  <option value="">San Martín 1234, Tigre</option>
				  <option value="">Alvear 1298, Benavidez</option>
				</select>
				<label>Elegí al repartidor: </label>
				<select id="Repartidos" name="Repartidos" class="campos-formulario">
				  <option value="">Mercado Libre</option>
				  <option value="">Reparto propio</option>
				</select>
				<button class="boton-formulario">Continuar</button>
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
		<p id="texto-modal">Esto es un texto modal: Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
		tempor incididunt ut labore et dolore magna aliqua.</p>
		<div class="contenedor-h alineacion-centrado-final">
			<button class="boton-formulario" id="aceptar-modal">Aceptar</button>
			<button class="boton-formulario" id="cancelar-modal">Cancelar</button>
		</div>
	</section>
</asp:Content>
