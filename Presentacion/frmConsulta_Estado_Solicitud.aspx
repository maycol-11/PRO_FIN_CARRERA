<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmConsulta_Estado_Solicitud.aspx.cs" Inherits="frmConsulta_Estado_Solicitud" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" style="width: 70%;">
            <tr>
                <td align="center" bgcolor="#FF6600" colspan="4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="XX-Large" ForeColor="White" Text="Consulta Estado Solicitud"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Text="Numero de Solicitud"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNumero_Solicitud" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Text="Estado de Solicitud"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtEstado_Solicitud" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
                <td align="center" colspan="2">
                    <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                        Text="Limpiar" Width="80px" />
                    <asp:Button ID="btnConsultar" runat="server" Font-Names="Arial" 
                        Text="Consultar" Width="80px" onclick="btnConsultar_Click" />
                </td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
                <td align="center" colspan="2">
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Names="Arial"></asp:Label>
                </td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
                <td align="center" colspan="2">
                    <asp:LinkButton ID="lbtnVolver" runat="server" Font-Bold="True" 
                        Font-Names="Arial" PostBackUrl="~/frmPrincipal.aspx">Volver</asp:LinkButton>
                </td>
                <td align="center">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
