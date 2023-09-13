<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioDisco.aspx.cs" Inherits="AppDiscosWeb.FormularioDisco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row mt-3">
        <div class="col-6">
            <div class="mb-3">
                <label for="textId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtTitulo" class="form-label">Titulo</label>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtFechaLanzamiento" class="form-label">Fecha Lanzamiento</label>
                <asp:TextBox ID="txtFechaLanzamiento" TextMode="DateTime" runat="server" CssClass="form-control"></asp:TextBox>
                                               
            </div>
            <div class="mb-3">
                <label for="cantidadCanciones" class="form-label">Cantidad Canciones</label>
                <asp:TextBox ID="txtCantidadCanciones" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtUrlImagenTapa" class="form-label">Url Imagen</label>
                 <asp:TextBox ID="txtUrlImagenTapa" runat="server" CssClass="form-control" OnTextChanged="txtUrlImagenTapa_TextChanged"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                <a href="Default.aspx" class="btn btn-primary">Cancelar</a>
            </div>

        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="ddlEstilo" class="form-label">Estilo</label>
                <asp:DropDownList ID="ddlEstilo" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
             <div class="mb-3">
                <label for="ddlEdicion" class="form-label">Estilo</label>
                <asp:DropDownList ID="ddlEdicion" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" ID="imgDisco" runat="server" Width="50%" />
            </div>
        </div>
    </div>
            

    <div class="row">
        <div class="col-6">
            

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                    </div>

                    <%if (ConfirmaEliminacion)
                        { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminacion" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button ID="btnConfirmaEliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click" />
                        </div>
                    <%  }%>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>

