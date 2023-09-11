<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListarDiscos.aspx.cs" Inherits="AppDiscosWeb.ListarDiscos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Discos</h1>
    <asp:GridView ID="dgvDiscos" runat="server" AutoGenerateColumns="false" CssClass="table">
        <Columns>
            
        </Columns>
    </asp:GridView>
</asp:Content>
