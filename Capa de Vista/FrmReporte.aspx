<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmReporte.aspx.cs" Inherits="ProyectoPlantas.CapaPresentacion.FrmReporte" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte de Plantas por Categoría</title>
</head>
<body>
    <form id="form1" runat="server" style="max-width: 600px; margin: auto; padding: 20px;">
        <h2>Reporte de Plantas por Categoría</h2>
        <asp:GridView ID="gvReporte" runat="server" AutoGenerateColumns="True" />
    </form>
</body>
</html>
