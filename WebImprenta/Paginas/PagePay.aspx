<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PagePay.aspx.cs" Inherits="WebImprenta.Paginas.PagePay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="Secciones contenedor-v" id="detalle-pago">
		<h1 class="titular-h2 margen-left-2vw">Pago</h1>
		<div class="contenedor-v alineacion-centrado-centrado" id="contenedor-grilla">
			<h2>Finalizá el pago</h2>

			<div class="tablon-claro contenedor-v alineacion-centrado-centrado">
				<h2 class="txt-familia-Rto txt-bold txt-1em3 entero">
						Pedido #<span id="txt-numero-pedido">00432119</span>	|	
						<span>julian@email.com</span>
				</h2>
				<div class="tablon-claro alineacion-around-inicio ">
					
					<div class="">
						<h3>Hoja</h3>
							<ul>
								<li>Tamaño: A4</li>
								<li>Tipo:Estucado</li>
								<li>Gramaje: 150gr</li>
							</ul>
					</div>
					<div class="">
						<h3>Calidad</h3>
							<ul>
								<li>Blanco y negro</li>
								<li>Alta</li>
								<li>Simple</li>
							</ul>
					</div><div class="">
						<h3>Detalles de<br /> impresión</h3>
							<ul>
								<li>Copias por hoja: 4</li>
								<li>Cantidad de copias: 2</li>
								<li>Margen (2mm): Si</li>
							</ul>
					</div>
					
				</div>


				<div class="contenedor-h entero alineacion-around-center">
					<div class="contenedor-v alineacion-centrado-inicio">
						<h3>Tipo de Pago</h3>
						<select id="TipoPago" name="TipoPago" class="campos-formulario">
						  <option value="">Toltal</option>
						  <option value="">Seña</option>
						</select>
					</div>
					<div class="contenedor-v alineacion-centrado-final">
						<h3>Impresión</h3>
						<p>$2350</p>
					</div>
					<div class="contenedor-v alineacion-centrado-final">
						<h3>Envio</h3>
						<p>$1350</p>
					</div>
					<div class="contenedor-v alineacion-centrado-final">
						<h3>PreTotal</h3>
						<p>$3700</p>
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
