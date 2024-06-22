﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3PensieroSebastian.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion{
            color: red;
            font-size: 12px;
        }
    </style>
    <script>
        function validar() {
            //captura el control
            const txtApellido = document.getElementById("txtApellido");
            if (txtApellido.value == "") {
                alert("debes cargar el apellido...");
                return false;
            }
            return true
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                
            </div>
            <div class ="mb-3">
                <label class="form-label">Apellido:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" ClientIDMode="Static" />
            </div>
            </div>
            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Imagen Perfil:</label>
                    <input type="file" id="txtImagen" runat="server" class="form-control" />
                </div>
                <asp:Image ID="imgNuevoPerfil" ImageUrl="https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg" 
                    runat="server" CssClass="img-fluid mb-3" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnGuardar" OnClick="btnGuardar_Click" OnClientClick="return validar()" runat="server" />
                <a href="/">Regresar</a>
            
        </div>
    </div>
</asp:Content>
