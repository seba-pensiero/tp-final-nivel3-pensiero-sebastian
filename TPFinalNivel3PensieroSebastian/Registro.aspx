<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinalNivel3PensieroSebastian.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <h2>Crear nuevo Perfil</h2>
            <div class="mb-3">
                <label class="form-label">Email:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" REQUIRED />
            </div>
            <div class="mb-3">
                <label class="form-label">Password:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" REQUIRED />
            </div>
            <asp:Button Text="Registrarse" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
            <a href="/">Cancelar</a>
        </div>
    </div>
</asp:Content>
