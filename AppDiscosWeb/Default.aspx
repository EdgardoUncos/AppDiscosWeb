<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppDiscosWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenido a Tu Catalogo de Discos</h1>

    <%-- Listado de Cards con forEacha--%>
    <%--<div class="row row-cols-1 row-cols-md-3 g-4">
        <%foreach (var item in ListaDiscos)
            {%>
        <div class="col">
            <div class="card">
                <img src="<%:item.UrlImagenTapa %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%:item.Titulo %></h5>
                    <p class="card-text"><%:item.Estilo.Descripcion%></p>
                    <a href="DetallePokemon.aspx?id=<%:item.Id %>">Ver Detalle</a>
                </div>
            </div>
        </div>

        <%} %>
    </div>--%>

    <%--Listado de Cards con Repeater--%>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidor" runat="server">

            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("UrlImagenTapa")%>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Titulo") %></h5>
                            <p class="card-text"><%#Eval("Estilo.Descripcion")%></p>
                            <asp:Button ID="btnDetalle" runat="server" Text="Ver Detalle" CssClass="btn btn-primary" CommandArgument='<%#Eval("Id") %>' CommandName="id" OnClick="btnDetalle_Click" />
                            <%--<a href="DetallePokemon.aspx?id=<%#Eval("Id") %>">Ver Detalle</a>--%>
                        </div>
                    </div>
                </div>
            </ItemTemplate>

        </asp:Repeater>
</asp:Content>
