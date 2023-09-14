<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListarDiscos.aspx.cs" Inherits="AppDiscosWeb.ListarDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de Discos</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" runat="server" ID="chkAvanzado"
                    AutoPostBack="true" OnCheckedChanged="Unnamed_CheckedChanged" />
            </div>
        </div>
    </div>

    <%if (chkAvanzado.Checked)

        { %>
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Campo" ID="lblCampo" runat="server"></asp:Label>
                <asp:DropDownList CssClass="form-control" ID="ddlCampo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Estilo"></asp:ListItem>
                    <asp:ListItem Text="Edicion"></asp:ListItem>
                    <asp:ListItem Text="Cantidad Canciones"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Criterio" ID="Label1" runat="server"></asp:Label>
                <asp:DropDownList CssClass="form-control" ID="ddlCriterio" runat="server">
                    
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Filtrar" ID="lblFiltro" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
            </div>

        </div>
    </div>


    <%} %>


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
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>
    <a href="FormularioDisco.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>

