<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PageRegistry.aspx.cs" Inherits="WebImprenta.Paginas.PageRegistry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript" src="../Scripts/CompotamientoGenerico.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	
    <section class="Secciones contenedor-v">
        <h1 class="titular-h2 margen-left-2vw">Registro</h1>
        <h3 class="contenedor-h alineacion-inicial-centrado margen-top-2vw">¡Solo un paso más! Completá los siguientes datos para poder completar el registro.</h3>
        <div class="contenedor-h">

            <div class="contenedor-v medio">
                <p class="txt-color-resaltado-2 txt-em9 margen-left-2vw">*Datos obligatorios.</p>
                <div class="contenedor-v alineacion-centrado-inicial margen-2em">

                    <div class="contenedor-h ">
                        <div class="contenedor-v tercio alineacion-centrado-inicial">
                            <label class="margen-bottom-0em9 margen-top-0em9">Nombre: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
                            <input type="text" size="30" name="" class="campo-formulario-registro-largo">

                            <label class="margen-bottom-0em9 margen-top-0em9">Apellido: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
                            <input type="text" size="30" name="" class="campo-formulario-registro-largo">

                            <label class="margen-bottom-0em9 margen-top-0em9">DNI: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
                            <input type="text" size="30" name="" class="campo-formulario-registro-largo">
                        </div>
                        <div class="contenedor-v alineacion-centrado-final margen-left-15vw">
                            <button type="button" class="boton-formulario margen-top-2vw">Actualizar</button>
                        </div>
                    </div>

                    <div class="contenedor-v alineacion-inicial-centrado">
                        <label class="margen-bottom-0em9 margen-top-0em9">Direcciones</label>
                        <ul>
                            <li class="contenedor-h alineacion-inicio-centrado margen-bottom-0em9">
                                <img class="imagen-icono-chica margen-right-0em9" src="../imagenes/iconos/delete.png">
                                Belgrano 1234, San Isidro  
                            </li>
                            <li class="contenedor-h alineacion-inicio-centrado margen-bottom-0em9">
                                <img class="imagen-icono-chica margen-right-0em9" src="../imagenes/iconos/delete.png">
                                Tucuman 2358, Las Cañitas   
                            </li>
                        </ul>
                    </div>

                    <div class="contenedor-v desplegable alineacion-inicial-centrado">
                        <label class="margen-bottom-0em9 margen-top-0em9"><span class="txt-color-resaltado-2 txt-em9 simbolo-desplegar">[+] </span>Agregar dirección</label>

                        <div class="contenedor-h alineacion-final-inicial">

                            <label class="margen-1em">Calle: </label>
                            <input type="text" size="20" name="" style="margin-top: .7em; height: 1.5em;" class="campo-formulario-registro-largo">
                        </div>

                        <div class="contenedor-h alineacion-final-inicial">

                            <label class="margen-1em">Nro.: </label>
                            <input type="text" size="8" style="margin-top: .7em; height: 1.5em;" name="" class="campo-formulario-registro-corto">

                            <label class="margen-1em">C.P.: </label>
                            <input type="text" size="5" style="margin-top: .7em; height: 1.5em;" name="" class="campo-formulario-registro-corto">

                            <label class="margen-1em">Ciudad: </label>
                            <input type="text" size="5" style="margin-top: .7em; height: 1.5em;" name="" class="campo-formulario-registro-corto">
                        </div>

                        <div class="contenedor-h alineacion-final-inicial">
                            <label class="margen-1em">Piso.: </label>
                            <input type="text" size="20" style="margin-top: .7em; height: 1.5em;" name="" class="campo-formulario-registro-corto">

                            <label class="margen-1em">Dto.: </label>
                            <input type="text" size="8" style="margin-top: .7em; height: 1.5em;" name="" class="campo-formulario-registro-corto">
                        </div>
                        <div class="contenedor-v alineacion-centrado-centrado">
                            <button type="button" class="boton-formulario margen-top-2vw">Agregar</button>

                        </div>
                    </div>

                </div>

            </div>
            <div class="contenedor-v alineacion-centrado-centrado" style="background-color: var(--fuxia); width: 2px;">
            </div>
            <div class="contenedor-v medio">
                <div class="contenedor-v alineacion-centrado-inicial margen-2em">

                    <label class="margen-1em">E-mail: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
                    <input type="text" size="30" name="" class="campo-formulario-registro-largo">

                    <label class="margen-1em">Cambio de clave</label>
                    <label class="margen-1em">Clave actual: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
                    <input type="text" size="30" name="" class="campo-formulario-registro-largo">

                    <label class="margen-1em">Clave: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
                    <input type="text" size="30" name="" class="campo-formulario-registro-largo">

                    <label class="margen-1em">Repetir clave: <span class="txt-color-resaltado-2 txt-em9 ">*</span></label>
                    <input type="text" size="30" name="" class="campo-formulario-registro-largo">

                    <div class="contenedor-v alineacion-centrado-centrado">
                        <button type="button" class="boton-formulario margen-top-2vw">Actualizar</button>
                    </div>
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
