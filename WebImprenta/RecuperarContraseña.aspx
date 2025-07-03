<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs" Inherits="WebImprenta.RecuperarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h3>Recuperar contraseña</h3>

    <div class="row">
        <!-- Campo Email -->
        <div class="col-md-6 mb-3">
            <label for="txtEmailRecuperar" class="form-label">Email</label>
            <asp:TextBox ID="txtEmailRecuperar" runat="server" CssClass="form-control" 
                         Placeholder="name@example.com" TextMode="Email" />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmailRecuperar" />
        
            <label for="txtContraseniaRecuperaro" class="form-label">Nueva contraseña</label>
            <asp:TextBox ID="txtContraseniaRecuperaro" runat="server" CssClass="form-control" 
                         TextMode="Password" Placeholder="Ingrese una nueva contraseña" />
            <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="txtContraseniaRecuperaro" />
        </div>
    </div>
    <asp:Label ID="lblError" runat="server" CssClass="form-text" />
    <!-- Botón -->
    <div class="col-12">
        <asp:Button ID="BtnGuardar" runat="server" Text="Actualizar" CssClass="btn btn-success mb-3" OnClick="BtnGuardar_Click" />
    </div>

    <!-- Mensaje -->
    <div class="col-12">
        <asp:Label ID="lblMensaje" runat="server" CssClass="form-text" />
    </div>
</asp:Content>