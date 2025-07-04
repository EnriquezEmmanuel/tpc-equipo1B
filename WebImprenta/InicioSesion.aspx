<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="WebImprenta.InicioSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container text-center">
        <div class="row">
            <div class="col-md-6 bg-info form-control w-75 mx-auto">
                <h3>Iniciar sesión</h3>

                <div class="mb-3">
                    <label for="Correo" class="form-label">Email</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control w-75 mx-auto" Placeholder="name@example.com" />
                </div>

                <div class="mb-3">
                    <label for="contraseña" class="form-label">Password</label>
                    <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control w-75 mx-auto" TextMode="Password" />
                </div>

                <div>
                    <asp:LinkButton ID="BtnRecuperarContraseña" Text="Recuperar contraseña" OnClick="BtnRecuperarContraseña_Click"  runat="server" />
                    <br />
                    <br />

                    <asp:Button ID="BtnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-primary mb-3" OnClick="BtnConfirmar_Click" />
                    <asp:Button ID="BtnRegistrarse" runat="server" Text="Registrarse" CssClass="btn btn-success mb-3" OnClick="BtnRegistrarse_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
