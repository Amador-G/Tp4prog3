<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4_PROG3.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            DESTINO INICIO<br />
            <br />
            Provincia :&nbsp;
            <asp:DropDownList ID="ddlProvinicio" runat="server" OnSelectedIndexChanged="ddlProvinicio_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            Localidad :
            <asp:DropDownList ID="ddlLocinicio" runat="server" OnSelectedIndexChanged="ddlLocinicio_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            DESTINO FINAL<br />
            <br />
            Provincia :
            <asp:DropDownList ID="ddlProvDestino" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            Localidad :
            <asp:DropDownList ID="ddlLocDestino" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblTest" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
