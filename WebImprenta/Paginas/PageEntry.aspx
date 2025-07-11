<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PageEntry.aspx.cs" Inherits="WebImprenta.Paginas.PageEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript" src="../Scripts/CompotamientoGenerico.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="contenedor-v" >

		<h1 class="titular-h2 margen-left-2vw">Iniciar Sesión</h1>
		<h2 class="contenedor-h alineacion-centrado-centrado margen-top-2vw margen-bottom-5vw ">Bienvenido</h2>
		<div class="contenedor-h margen-bottom-5vw ">

			<div class="contenedor-v medio">
				<h3 class="margen-right-10vw">Inicia Sesión</h3>
				<div class="contenedor-v alineacion-centrado-centrado margen-2em">

					
					<label class="margen-1em">Usuario</label>
                    <asp:TextBox runat="server" ID="tbxUsuario" />

					<label  class="margen-1em">Clave</label>
					<asp:TextBox runat="server" ID="tbxClave" TextMode="Password"/>

					<asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="boton-formulario" OnClick="btnIngresar_Click" />

				</div>
					<a href="PageLossPass.aspx" class="txt-color-resaltado-2 txt-em9 margen-left-5vw">Olvidé mi usuario</a>

			</div>	
			<div class="contenedor-v alineacion-centrado-centrado" style="background-color:var(--fuxia);width: 2px;">
					<div class="contenedor-v alineacion-centrado-centrado" style="background-color:var(--azulOscuro);height: 2em;">ó</div>
			</div>
			<div class="contenedor-v medio">
				<h3 class="margen-right-10vw">Regístrate</h3>
				<div class="contenedor-v alineacion-centrado-centrado margen-2em">

					<label class="margen-1em">Nombre</label>
					<asp:TextBox ID="tbxNombre" runat="server" />

					<label  class="margen-1em">E-mail</label>
					<asp:TextBox ID="tbxEmail" runat="server"/>

					<asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" CssClass="boton-formulario" OnClick="btnRegistrarse_Click"/>

				</div>

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
