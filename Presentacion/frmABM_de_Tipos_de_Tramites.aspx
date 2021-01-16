<%@ Page Title="" Language="C#" MasterPageFile="~/mpUsuario.master" AutoEventWireup="true" CodeFile="frmABM_de_Tipos_de_Tramites.aspx.cs" Inherits="frmABM_de_Tipos_de_Tramites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="X-Large" Text="ABM de Tipo de Tramites"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text="Entidad:   "></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlEntidades" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text="Codigo:   "></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtCodigo" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text="Nombre:     "></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text="Descripcion:   "></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtDescripcion" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center" colspan="2">
                <asp:Button ID="btnLimpiar" runat="server" Font-Names="Arial" Text="Limpiar" 
                    Width="80px" onclick="btnLimpiar_Click" />
                <asp:Button ID="btnBuscar" runat="server" Font-Names="Arial" Text="Buscar" 
                    Width="80px" onclick="btnBuscar_Click" />
                <asp:Button ID="btnAgregar" runat="server" Font-Names="Arial" Text="Agregar" 
                    Width="80px" onclick="btnAgregar_Click" />
                <asp:Button ID="btnModificar" runat="server" Font-Names="Arial" 
                    Text="Modificar" Width="80px" onclick="btnModificar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Font-Names="Arial" Text="Eliminar" 
                    Width="80px" onclick="btnEliminar_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center" colspan="2">
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Names="Arial" 
                    ForeColor="#FF3300"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center" colspan="2">
                <asp:LinkButton ID="lbtnVolver" runat="server" Font-Bold="True" 
                    Font-Names="Arial" PostBackUrl="~/frmPrincipal.aspx">Volver</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

