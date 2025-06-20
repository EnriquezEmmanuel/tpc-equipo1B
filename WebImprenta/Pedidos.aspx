<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="WebImprenta.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .bloque-personalizado {
            background-color: lightgrey;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            margin-bottom: 30px;
            color: #000;
        }
    </style>

    <script>
        (() => {
            'use strict'
            const forms = document.querySelectorAll('form')
            Array.from(forms).forEach(form => {
                form.addEventListener('submit', event => {
                    if (!form.checkValidity()) {
                        event.preventDefault()
                        event.stopPropagation()
                    }
                    form.classList.add('was-validated')
                }, false)
            })
        })()
    </script>

    <<script>
         function validarFormulario() {
             const form = document.getElementById('form1');

             form.classList.add('was-validated');

             if (!form.checkValidity()) {
                 return false; 
             }

             return true; 
         }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container py-5">
        <h1 class="row justify-content-center">Impresion</h1>
        <!-- BLOQUE HOJA -->
        <div class="row justify-content-center">
            <div class="col-md-6 bloque-personalizado">
                <h4 class="mb-4">Hoja</h4>

                <div class="mb-3">
                    <label class="form-label">Tipo de papel</label>
                    <select class="form-select" id="tipoPapel" required>
                        <option value="" selected disabled>Seleccione un tipo de papel</option>
                        <option value="1">Papel estucado</option>
                        <option value="2">Papel offset</option>
                        <option value="3">Papel fotográfico</option>
                        <option value="4">Cartulina</option>
                        <option value="5">Papel opalina</option>
                        <option value="6">Papel ilustración</option>
                        <option value="7">Papel autoadhesivo</option>
                    </select>
                    <div class="invalid-feedback">
                        seleccione un tipo de papel.
                    </div>
                </div>

                <div class="mb-3">
                    <label class="form-label">Tamaño</label>
                    <select class="form-select" id="tamaño" required>
                        <option value="" selected disabled>Seleccione un tamaño</option>
                        <option value="1">A3</option>
                        <option value="2">A4</option>
                        <option value="3">A5</option>
                    </select>
                    <div class="invalid-feedback">
                        Seleccione un tamaño.
                    </div>
                </div>

                <div class="mb-3">
                    <label class="form-label">Gramaje</label>
                    <select class="form-select" id="gramaje" required>
                        <option value="" selected disabled>Seleccione un gramaje</option>
                        <option value="1">75 grs</option>
                        <option value="2">90 grs</option>
                        <option value="3">120 grs</option>
                        <option value="4">150 grs</option>
                    </select>
                    <div class="invalid-feedback">
                        Seleccione un gramaje.
                    </div>
                </div>
            </div>
        </div>

        <!-- BLOQUE CALIDAD -->
        <div class="row justify-content-center">
            <div class="col-md-6 bloque-personalizado">
                <h4 class="mb-4">Calidad</h4>

                <div class="form-check mb-2">
                    <input class="form-check-input" type="checkbox" id="chkColor">
                    <label class="form-check-label" for="chkColor">Color</label>
                </div>

                <div class="form-check mb-3">
                    <input class="form-check-input" type="checkbox" id="chkDobleCara">
                    <label class="form-check-label" for="chkDobleCara">Doble cara</label>
                </div>

                <div class="mb-3">
                    <label class="form-label">Calidad</label>
                    <select class="form-select" id="calidadSelect" required>
                        <option value="" selected disabled>Seleccione Calidad</option>
                        <option value="1">Rápida</option>
                        <option value="2">Óptima</option>
                        <option value="3">Alta</option>
                    </select>
                    <div class="invalid-feedback">
                        Seleccione una calidad.
                    </div>
                </div>
            </div>
        </div>

        <!-- BLOQUE COPIAS -->
        <div class="row justify-content-center">
            <div class="col-md-6 bloque-personalizado">
                <h4 class="mb-4">Copias</h4>

                <div class="mb-3">
                    <label class="form-label">Copias por hoja</label>
                    <input type="number" class="form-control" min="1" step="1" value="1" required />
                    <div class="invalid-feedback">Ingrese una cantidad válida.</div>
                </div>

                <div class="mb-3">
                    <label class="form-label">Márgenes (mm)</label>
                    <input type="number" class="form-control" min="0" step="1" value="0" required />
                    <div class="invalid-feedback">Ingrese un valor válido para los márgenes.</div>
                </div>

                <div class="mb-4">
                    <label class="form-label">Número de copias</label>
                    <input type="number" class="form-control" min="1" step="1" value="1" required />
                    <div class="invalid-feedback">Ingrese el número de copias.</div>
                </div>

                <div class="d-grid">
                    <asp:Button Text="Aceptar" ID="btnAceptar" runat="server" CssClass="btn btn-primary btn-lg" OnClientClick="return validarFormulario();" OnClick="btnAceptar_Click" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>
