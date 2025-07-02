<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PageSession.aspx.cs" Inherits="WebImprenta.Paginas.PageSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="Secciones contenedor-v" >
		<h1 class="titular-h2 margen-left-2vw">Iniciar Sesión</h1>
		<h2 class="contenedor-h alineacion-centrado-centrado margen-top-2vw">Bienvenido</h2>
		<div class="contenedor-h">

			<div class="contenedor-v medio">
				<h3 class="margen-right-10vw">Inicia Sesión</h3>
				<div class="contenedor-v alineacion-centrado-centrado margen-2em">

					
					<label class="margen-1em">Usuario</label>
					<input type="text" size="30" name="">

					<label  class="margen-1em">Clave</label>
					<input type="password" size="30" name="">

					<button type="button" class="boton-formulario" id="btn-abrir-modal">Ingresar</button>

				</div>
					<a href="" class="txt-color-resaltado-2 txt-em9 margen-left-5vw">Olvidé mi usuario</a>

			</div>	
			<div class="contenedor-v alineacion-centrado-centrado" style="background-color:var(--fuxia);width: 2px;">
					<div class="contenedor-v alineacion-centrado-centrado" style="background-color:var(--azulOscuro);height: 2em;">ó</div>
			</div>
			<div class="contenedor-v medio">
				<h3 class="margen-right-10vw">Regístrate</h3>
				<div class="contenedor-v alineacion-centrado-centrado margen-2em">

					<label class="margen-1em">Nombre</label>
					<input type="text" size="30" name="">

					<label  class="margen-1em">E-mail</label>
					<input type="password" size="30" name="">

					<button type="button" class="boton-formulario" id="btn-abrir-modal">Ingresar</button>
				</div>

			</div>
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
