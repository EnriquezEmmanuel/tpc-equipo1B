<%@ Page Title="Resultado del Pago" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Resultado.aspx.cs" Inherits="WebImprenta.Paginas.Resultado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Resultado del Pago</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center; margin-top: 50px;">
        <asp:Label ID="lblResultado" runat="server" Font-Bold="true" Font-Size="X-Large" />
    </div>
</asp:Content>