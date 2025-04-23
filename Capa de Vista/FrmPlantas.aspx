<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPlantas.aspx.cs" Inherits="WebApplication2.CapaDeVista.FrmPlantas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Plantas</title>
    <style>
        body {
            background-color: #f0f4f8;
            font-family: 'Segoe UI', sans-serif;
            padding: 30px;
        }

        .container {
            background-color: #ffffff;
            padding: 30px;
            max-width: 900px;
            margin: auto;
            border-radius: 10px;
            box-shadow: 0px 0px 12px rgba(0,0,0,0.1);
        }

        h2 {
            text-align: center;
            color: #2c3e50;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            font-weight: bold;
        }

        input[type="text"], textarea, select {
            width: 100%;
            padding: 10px;
            margin-top: 5px;
            border: 1px solid #ccc;
            border-radius: 6px;
        }

        .button-group {
            text-align: center;
            margin-top: 20px;
        }

        .button-group asp\:Button {
            margin: 5px;
        }

        .gridview {
            margin-top: 30px;
            width: 100%;
            border-collapse: collapse;
        }

        .gridview th, .gridview td {
            padding: 10px;
            border: 1px solid #ccc;
        }

        .gridview th {
            background-color: #ecf0f1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Gestión de Plantas</h2>

            <div class="form-group">
                <asp:Label ID="lblID" runat="server" Text="ID:" />
                <asp:TextBox ID="txtID" runat="server" Enabled="false" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" />
                <asp:TextBox ID="txtNombre" runat="server" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:" />
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblCategoria" runat="server" Text="Categoría:" />
                <asp:DropDownList ID="ddlCategoria" runat="server" />
            </div>

            <div class="button-group">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" Enabled="false" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblFiltro" runat="server" Text="Filtrar por categoría:" />
                <asp:DropDownList ID="ddlFiltroCategoria" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFiltroCategoria_SelectedIndexChanged" />
            </div>

            <asp:GridView ID="gvPlantas" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPlantas_RowCommand" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
                    <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar"
                                CommandName="Seleccionar" CommandArgument='<%# Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"
                                CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
