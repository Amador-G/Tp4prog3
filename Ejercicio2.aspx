<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4_PROG3.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Id Producto:
            <asp:DropDownList ID="ddlProducto" runat="server">
                <asp:ListItem Value="0">Igual a:</asp:ListItem>
                <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                <asp:ListItem Value="2">Menor a:</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
            <br />
            <br />
            Id Categoria:
            <asp:DropDownList ID="ddlCategoria" runat="server">
                <asp:ListItem Value="0">Igual a:</asp:ListItem>
                <asp:ListItem Value="1">Mayor a:</asp:ListItem>
                <asp:ListItem Value="2">Menor a:</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBorrar" runat="server" OnClick="btnBorrar_Click" Text="Quitar Filtro" />
            <br />
&nbsp;<asp:GridView ID="grdProductos" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
