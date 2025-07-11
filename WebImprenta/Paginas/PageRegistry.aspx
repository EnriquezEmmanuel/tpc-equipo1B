<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PageRegistry.aspx.cs" Inherits="WebImprenta.Paginas.PageRegistry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        label.simbolo-desplegar {
            z-index: 1;
            position: relative;
        }
    </style>
    <script type="text/javascript" src="../Scripts/CompotamientoGenerico.js"></script>
    <script>
    window.addEventListener('DOMContentLoaded', function () {
        document.getElementById('<%= txtDto.ClientID %>').value = '';
    });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	
    <section class="Secciones contenedor-v">
        <h1 class="titular-h2 margen-left-2vw">Registro</h1>
        <h3 class="contenedor-h alineacion-inicial-centrado margen-top-2vw">¡Solo un paso más! Completá los siguientes datos para poder completar el registro.</h3>

        <div class="contenedor-h">

            <div class="contenedor-v medio">
                <p class="txt-color-resaltado-2 txt-em9 margen-left-2vw">*Datos obligatorios.</p>


                <div class="contenedor-v alineacion-centrado-inicial margen-2em">

                    <div class="contenedor-h">
                        <div class="contenedor-v tercio alineacion-centrado-inicial">
                            <label class="margen-bottom-0em9 margen-top-0em9">Nombre: <span class="txt-color-resaltado-2 txt-em9">*</span></label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="campo-formulario-registro-largo" />

                            <label class="margen-bottom-0em9 margen-top-0em9">Apellido: <span class="txt-color-resaltado-2 txt-em9">*</span></label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="campo-formulario-registro-largo" />

                            <label class="margen-bottom-0em9 margen-top-0em9">DNI: <span class="txt-color-resaltado-2 txt-em9">*</span></label>
                            <asp:TextBox ID="txtDni" runat="server" CssClass="campo-formulario-registro-largo" />
                        </div>

                        <div class="contenedor-v alineacion-centrado-final margen-left-15vw">
                            <asp:Button ID="btnActualizarDatos" runat="server" Text="Actualizar"
                                CssClass="boton-formulario margen-top-2vw"
                                OnClick="btnActualizarDatos_Click" />

                        </div>
                    </div>

                    <div class="contenedor-v alineacion-inicial-centrado">
                        <label class="margen-bottom-0em9 margen-top-0em9">Direcciones</label>
                        <asp:Repeater ID="rptDirecciones" runat="server" OnItemCommand="rptDirecciones_ItemCommand">
                            <ItemTemplate>
                                <li class="contenedor-h alineacion-inicio-centrado margen-bottom-0em9">
                                    <img class="imagen-icono-chica margen-right-0em9" src="../imagenes/iconos/delete.png" />
                                    <%# Eval("Calle") %> <%# Eval("Altura") %>, <%# Eval("Ciudad") %>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <div class="contenedor-v alineacion-inicial-centrado margen-top-2em direccion-campos">

                        <h4 class="txt-bold margen-bottom-1em">Agregar dirección</h4>

                        <div>
                            <label class="margen-1em">Calle: </label>
                            <asp:TextBox ID="txtCalle" runat="server" CssClass="campo-formulario-registro-largo" />
                        </div>

                        <div class="contenedor-h alineacion-inicio-inicial margen-top-1em" style="gap: 1rem;">
                            <div>
                                <label class="margen-1em">Nro.: </label>
                                <asp:TextBox ID="txtAltura" runat="server" CssClass="campo-formulario-registro-corto" />
                            </div>
                            <div>
                                <label class="margen-1em">C.P.: </label>
                                <asp:TextBox ID="txtCP" runat="server" CssClass="campo-formulario-registro-corto" />
                            </div>
                            <div>
                                <label class="margen-1em">Ciudad: </label>
                                <asp:TextBox ID="txtCiudad" runat="server" CssClass="campo-formulario-registro-corto" />
                            </div>
                        </div>

  
                        <div class="contenedor-h alineacion-inicio-inicial margen-top-1em" style="gap: 1rem;">
                            <div>
                                <label class="margen-1em">Piso: </label>
                                <asp:TextBox ID="txtPiso" runat="server" CssClass="campo-formulario-registro-corto" autocomplete="off" />
                            </div>
                            <div>
                                <label class="margen-1em">Dto.: </label>
                                <asp:TextBox ID="txtDto" runat="server" CssClass="campo-formulario-registro-corto" autocomplete="new-password" />
                            </div>
                        </div>

                        <div class="contenedor-v alineacion-centrado-centrado margen-top-2em">
                            <asp:Button ID="btnAgregarDireccion" runat="server" Text="Agregar"
                                CssClass="boton-formulario"
                                OnClick="btnAgregarDireccion_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="contenedor-v alineacion-centrado-centrado" style="background-color: var(--fuxia); width: 2px;"></div>


            <div class="contenedor-v medio">
                <div class="contenedor-v alineacion-centrado-inicial margen-2em">
                    <label class="margen-1em">E-mail:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="campo-formulario-registro-largo" Enabled="false" />

                    <label class="margen-1em">Cambio de clave</label>
                    <label class="margen-1em">Clave actual:</label>
                    <asp:TextBox ID="txtClaveActual" runat="server" CssClass="campo-formulario-registro-largo" TextMode="Password" />

                    <label class="margen-1em">Nueva clave:</label>
                    <asp:TextBox ID="txtClaveNueva" runat="server" CssClass="campo-formulario-registro-largo" TextMode="Password" />

                    <label class="margen-1em">Repetir clave:</label>
                    <asp:TextBox ID="txtClaveRepetir" runat="server" CssClass="campo-formulario-registro-largo" TextMode="Password" />

                    <div class="contenedor-v alineacion-centrado-centrado">
                        <asp:Button ID="btnActualizarUsuario" runat="server" Text="Actualizar"
                            CssClass="boton-formulario margen-top-2vw"
                            OnClick="btnActualizarUsuario_Click" />
                    </div>
                </div>
            </div>
        </div>


        <div class="contenedor-v alineacion-centrado-centrado">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar"
                CssClass="boton-formulario margen-top-2vw"
                OnClick="btnAceptar_Click" />
        </div>
    </section>

    <section id="ventana-modal">
        <asp:Label ID="TextoModal" runat="server" Text="" />
        <div class="contenedor-h alineacion-centrado-final">
            <button class="boton-formulario" id="cancelar-modal">Aceptar</button>
        </div>
    </section>

</asp:Content>
