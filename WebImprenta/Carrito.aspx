<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebImprenta.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container text-center">
        <div class="row">
            <div class="col-md-6 bg-secondary text-white p-4">
                <h3>Datos de Envío</h3>



                <div class="container mt-5">
                    <h5>¿Dónde querés que te mandemos el pedido?</h5>

                    <ul class="list-group">
                        <asp:Repeater ID="rptDirecciones" runat="server">
                            <ItemTemplate>
                                <li class="list-group-item d-flex justify-content-between align-items-center">
                                    <span>
                                        <%# ((Dominio.Direccion)Container.DataItem).ToString() %>
                                    </span>

                                    <asp:Button ID="btnSeleccionar" runat="server"
                                        CommandName="SeleccionarDireccion"
                                        CommandArgument='<%# Eval("Id") %>'
                                        Text="✅"
                                        OnCommand="btnSeleccionar_Command"
                                        CssClass="btn btn-outline-primary btn-sm" />
                                </li>
                            </ItemTemplate>

                        </asp:Repeater>
                    </ul>
                    
                    <asp:Label ID="txtError"  runat="server" />
                </div>


              


            </div>
            <div class="col-md-6 bg-dark bg-opacity-25 text-white p-4">
                <div style="text-align: center">
                    <h3>Pago</h3>
                    <p>Total: <strong>$1500</strong></p>
                    <asp:Button ID="btnPagar" runat="server" Text="Pagar con Mercado Pago" CssClass="btn btn-primary" OnClick="btnPagar_Click" />
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </div>
                <asp:Button Text="Cancelar" ID="btnCancelar" class="btn btn-primary me-2" OnClick="btnCancelar_Click" runat="server" />
            </div>
        </div>
    </div>


</asp:Content>