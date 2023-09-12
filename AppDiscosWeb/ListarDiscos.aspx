<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListarDiscos.aspx.cs" Inherits="AppDiscosWeb.ListarDiscos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Discos</h1>
    <asp:GridView ID="dgvDiscos" runat="server" AutoGenerateColumns="false" 
        DataKeyNames="Id" CssClass="table"
        OnSelectedIndexChanged="dgvDiscos_SelectedIndexChanged"
        OnPageIndexChanging="dgvDiscos_PageIndexChanging"
        AllowPaging="true" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
            <asp:BoundField HeaderText="Lanzamiento" DataField="FechaLanzamiento" />
            <asp:BoundField HeaderText="Cant Canciones" DataField="CantidadCanciones" />
            <asp:BoundField HeaderText="Estilo" DataField="Estilo.Descripcion" />
            <asp:BoundField HeaderText="Edicion" DataField="TipoEdicion.Descripcion" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Seleccionar" />
        </Columns>
    </asp:GridView>
    <a href="FormularioDisco.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>

