<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageMPfalsa.aspx.cs" Inherits="WebImprenta.Paginas.PageMPfalsa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MP falso</title>
	<link rel="stylesheet" type="text/css" href="../Content/estilos-propios.css" />
    <link rel="stylesheet" type="text/css" href="../Content/estilos-prefijados-propios.css" />

    <style>
		#Contenedor-mp{
			background-image: url("../imagenes/fnd-MP.png") ;
			width: 100vw;
			height: 100vh;
		}
		.boton-formulario-mp{
			font: 1,2em Roboto;
			font-weight: bold;
			background-color: white;
			color: var(--azulCasiOscuro);
			border-radius: 10px;
			border-style: none;
			padding:1em;
			margin: 1em;
			border:2px solid var(--celeste);
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Contenedor-mp" class="contenedor-v alineacion-centrado-centrado">
		
		<div class="contenedor-h alineacion-centrado-centrado">
			<p id="Contenido" class=" txt-color-oscuro tercio">
				Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
				tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
				quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
				consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
				cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
				proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
			</p>
		</div>
		<div>
			<asp:Button ID="btnAceptar" runat="server" CssClass="boton-formulario-mp" Text="Pago Aceptado" />
			<asp:Button ID="btnRechazar" runat="server" CssClass="boton-formulario-mp" Text="Pago Rechazado" />
		</div>
		

	</div>
    </form>
</body>
</html>
