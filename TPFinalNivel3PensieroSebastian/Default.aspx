<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3PensieroSebastian.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Artículos</h1>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card" style="height: 300px">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="..." style="height:50%">
                        <div class="card-body">
                            <h5 class="card-title"><a href ="/DetallesArticulo.aspx?id=<%#Eval("Id") %>"><%#Eval("Nombre") %></a></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
