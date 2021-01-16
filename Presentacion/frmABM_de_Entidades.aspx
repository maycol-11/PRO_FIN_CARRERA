<%@ Page Title="" Language="C#" MasterPageFile="~/mpUsuario.master" AutoEventWireup="true" CodeFile="frmABM_de_Entidades.aspx.cs" Inherits="frmABM_de_Entidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td align="center" colspan="4">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                Font-Size="X-Large" Text="ABM Entidades"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="center">
            &nbsp;</td>
        <td align="center">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="right">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" 
                Text="Nombre"></asp:Label>
        </td>
        <td align="left">
            <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="right">
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" 
                Text="Direccion"></asp:Label>
        </td>
        <td align="left">
            <asp:TextBox ID="txtDireccion" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="right">
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" 
                Text="Telefono"></asp:Label>
        </td>
        <td align="left">
            <asp:TextBox ID="txtTelefono" runat="server" Width="200px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="center" colspan="2">
            <asp:Button ID="btnAgregarTelefono" runat="server" 
                onclick="btnAgregarTelefono_Click" Text="Agregar Telefono" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="right">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="center" colspan="2">
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" 
                Text="Lista de Telefonos"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="center" colspan="2">
            <asp:ListBox ID="lstbLista_Telefonos" runat="server" Width="200px"></asp:ListBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="center">
            &nbsp;</td>
        <td align="center">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="center" colspan="2">
            <asp:Button ID="btnEliminarTelefono" runat="server" 
                Text="Eliminar Telefono Seleccionado" 
                onclick="btnEliminarTelefono_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="center">
            &nbsp;</td>
        <td align="center">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="center" colspan="2">
            <asp:Button ID="btnLimpiar" runat="server" 
                Text="Limpiar" Width="80px" onclick="btnLimpiar_Click" />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="80px" 
                onclick="btnBuscar_Click" />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="80px" 
                onclick="btnAgregar_Click" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="80px" 
                onclick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Width="80px" 
                onclick="btnEliminar_Click" />
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
                ForeColor="Red"></asp:Label>
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

