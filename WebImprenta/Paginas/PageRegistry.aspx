<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageRegistry.aspx.cs" Inherits="WebImprenta.Paginas.PageRegistry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro</title>
	<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Content/estilos-propios.css") %>"/>
	<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Content/estilos-prefijados-propios.css") %>"/>
	
</head>
<body>
    <form id="form1" runat="server">
        <section class="Secciones contenedor-v" >
		<h1 class="titular-h2 margen-left-2vw">Registro</h1>
			<h3 class="contenedor-h alineacion-inicial-centrado margen-top-2vw">¡Solo un paso más! Completá los siguientes datos para poder completar el registro.</h2>
		<div class="contenedor-h">

			<div class="contenedor-v medio">
				<h3 class="margen-right-10vw">Inicia Sesión</h3>
				<div class="contenedor-v alineacion-centrado-inicial margen-2em">

					
					<label class="margen-1em">Nombre: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
					<input type="text" size="30" name="">

					<label  class="margen-1em">Apellido: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
					<input type="text" size="30" name="">

					<label  class="margen-1em">Direccion <span class="txt-color-resaltado-2 txt-em9 ">(Podés ingresarla más tarde.)</span></label>

					<div class="contenedor-h" class="contenedor-h alineacion-final-inicial">

						<label  class="margen-1em">Calle: </label>
						<input type="text" size="20" name="" style="margin-top: .7em; height: 1.2em;">

					</div>

					<div class="contenedor-h" class="contenedor-h alineacion-final-inicial">

						<label class="margen-1em">Nro.: </label>
						<input type="text" size="8"  style="margin-top: .7em; height: 1.2em;" name="">
						<label  class="margen-1em">C.P.: </label>
						<input type="text" size="5" style="margin-top: .7em; height: 1.2em;" name="">
					</div>

					<div class="contenedor-h" class="contenedor-h alineacion-final-inicial">
						<label class="margen-1em">Piso.: </label>
						<input type="text" size="20"  style="margin-top: .7em; height: 1.2em;" name="">
						<label  class="margen-1em">Dto.: </label>
						<input type="text" size="8" style="margin-top: .7em; height: 1.2em;" name="">
					</div>
					
				</div>
					<a href="" class="txt-color-resaltado-2 txt-em9 margen-left-2vw">*Datos obligatorios.</a>

			</div>	
			<div class="contenedor-v alineacion-centrado-centrado" style="background-color:var(--fuxia);width: 2px;">
			</div>
			<div class="contenedor-v medio">
				<h3 class="margen-right-10vw">Regístrate</h3>
				<div class="contenedor-v alineacion-centrado-inicial margen-2em">

					<label class="margen-1em">E-mail: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
					<input type="text" size="30" name="">

					<label  class="margen-1em">Usuario: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
					<input type="text" size="30" name="">

					<label class="margen-1em">Clave: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
					<input type="text" size="30" name="">

					<label class="margen-1em">Repetir clave: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
					<input type="text" size="30" name="">

					<button type="button" class="boton-formulario margen-top-2vw" id="btn-abrir-modal">Registrar datos</button>
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
    </form>
</body>
</html>
