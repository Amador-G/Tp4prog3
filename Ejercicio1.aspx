<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4_PROG3.Ejercicio1bis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ORIGEN<br />
            <br />
            Provincia :
            <asp:DropDownList ID="ddlPorigen" runat="server" AutoPostBack="True" OnSelectedIndexChanged="OrigenSeleccionado">
            </asp:DropDownList>
            <br />
            <br />
            Localidad :
            <asp:DropDownList ID="ddlLorigen" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            DESTINO<br />
            <br />
            <asp:ScriptManager runat="server" ID="SM1" />    
            <asp:UpdatePanel ID="UPLocalidadDestino" runat="server">
                <ContentTemplate>
                    Provincia :
                    <asp:DropDownList ID="ddlPdestino" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DestinoSeleccionado">
                    </asp:DropDownList>
            <br />
            <br />
                    Localidad :
                    <asp:DropDownList ID="ddlLdestino" runat="server">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
