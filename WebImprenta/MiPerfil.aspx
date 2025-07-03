<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="WebImprenta.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-6 bg-primary text-white p-4">

            <h3>Datos del Usuario</h3>

            <div class="row">
                <div class="col-md-6 mb-3">
                    <label for="txtDni">N° Documento</label>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6 mb-3">
                    <label for="txtApellido">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6 mb-3">
                    <label for="txtNombre">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <asp:Button ID="btnActualizarDatos" runat="server" Text="Actualizar Datos" OnClick="btnActualizarDatos_Click" CssClass="btn btn-success" />
            <br />
            <br />

            <h4>Direcciones</h4>


            <asp:Repeater ID="rptDirecciones" runat="server" OnItemCommand="rptDirecciones_ItemCommand1">
                <ItemTemplate>
                    <div class="row align-items-center mb-2">
                        <div class="col-10">
                            <label>Dirección <%# Container.ItemIndex + 1 %></label><br />
                            <asp:Label ID="lblDireccion" runat="server"
                                Text='<%# Container.DataItem.ToString() %>'
                                CssClass="form-control-plaintext" />
                        </div>
                        <div class="col-2 text-end">

                            <div class="col-2 text-end">
                                <asp:Button ID="btnEliminar" runat="server"
                                    CssClass="btn btn-danger"
                                    Text="Eliminar"
                                    CommandName="Eliminar"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>'
                                    OnClientClick="return confirm('¿Está seguro de que desea eliminar esta dirección?');"  />
                            </div>
                          
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>





            <h5>Agregar nueva dirección</h5>

            <div class="row">
                <div class="col-md-6 mb-3">
                    <label for="txtCalleNueva">Calle</label>
                    <asp:TextBox ID="txtCalleNueva" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-3">
                    <label for="txtAlturaNueva">Altura</label>
                    <asp:TextBox ID="txtAlturaNueva" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-3">
                    <label for="txtDepartamentoNuevo">Departamento</label>
                    <asp:TextBox ID="txtDepartamentoNuevo" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-3">
                    <label for="txtPisoNuevo">Piso</label>
                    <asp:TextBox ID="txtPisoNuevo" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-3">
                    <label for="txtCodigoPostal">Codigo Postal</label>
                    <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-3">
                    <label for="txtCiudad">Ciudad</label>
                    <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
                </div>
            </div>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="d-block mb-2" Visible="false" />
            <asp:Button ID="btnGuardarDirecciones" runat="server" Text="Guardar Dirección" OnClick="btnGuardarDirecciones_Click" CssClass="btn btn-success" />



        </div>
    </div>
</asp:Content>