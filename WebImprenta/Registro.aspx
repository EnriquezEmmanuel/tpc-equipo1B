<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebImprenta.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h3>Formulario de registro</h3>

    <div class="col-md-6 position-relative">
        <label for="txtEmailRegistro" class="form-label">Email</label>
        <div class="input-group has-validation">
            <asp:TextBox ID="txtEmailRegistro" runat="server" CssClass="form-control" Placeholder="name@example.com" TextMode="Email" />
            <div class="invalid-tooltip">
                Por favor, ingresá un Email válido. 
            </div>
        </div>
    </div>

    <div class="col-md-6 position-relative">
        <label for="txtContraseniaRegistro" class="form-label">Contraseña</label>
        <div class="input-group has-validation">
            <asp:TextBox ID="txtContraseniaRegistro" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Ingrese una Contraseña" />
            <div class="invalid-tooltip">
                Por favor, ingresá una Contraseña válida.
            </div>
        </div>
    </div>


    <div class="col-12">
        <br />

        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success mb-3" OnClick="BtnGuardar_Click" />
    </div>




</asp:Content>
