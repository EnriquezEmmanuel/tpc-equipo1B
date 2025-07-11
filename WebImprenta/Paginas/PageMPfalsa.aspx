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
            <asp:TextBox ID="tbxRespuesta" Cols="10" Rows="10" runat="server" TextMode="MultiLine"/>
		</div>
		<div>
			<asp:Button ID="btnAceptar" runat="server" CssClass="boton-formulario-mp" Text="Pago Aceptado" />
			<asp:Button ID="btnRechazar" runat="server" CssClass="boton-formulario-mp" Text="Pago Rechazado" />
		</div>
		

	</div>
    </form>
</body>
</html>
