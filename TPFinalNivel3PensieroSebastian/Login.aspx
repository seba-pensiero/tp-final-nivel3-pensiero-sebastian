﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3PensieroSebastian.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <h2>Login</h2>
            <div class="mb-3">
                <label class="form-label">Email:</label>
                <asp:TextBox runat="server" CssClass="form-control" REQUIRED ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" REQUIRED />
            </div>
            <asp:Button Text="Ingresar" runat="server" CssClass="btn btn-primary" ID="btnLogin" OnClick="btnLogin_Click" />
            <a href="/">Cancelar</a>
        </div>
    </div>
</asp:Content>
