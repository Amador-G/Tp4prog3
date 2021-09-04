<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3b.aspx.cs" Inherits="TP4_PROG3.Ejercicio2b" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Listado de libros:<br />
            <br />
            <asp:GridView ID="gvLibro" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnOtroTema" runat="server" OnClick="btnOtroTema_Click" Text="Consultar otro tema" />
        </div>
    </form>
</body>
</html>
