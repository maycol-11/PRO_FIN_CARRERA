<%@ Page Title="" Language="C#" MasterPageFile="~/mpUsuario.master" AutoEventWireup="true" CodeFile="frmListado_Solicitudes_por_Fecha.aspx.cs" Inherits="frmListado_Solicitudes_por_Fecha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="X-Large" Text="Listado de Solicitudes por Fecha"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td align="center">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text="Fecha:"></asp:Label>
                <asp:TextBox ID="txtFecha" runat="server" Font-Bold="True" Font-Names="Arial">yyyy-mm-dd</asp:TextBox>
                <asp:Button ID="btnListar" runat="server" Font-Bold="True" Font-Names="Arial" 
                    onclick="btnListar_Click" Text="Listar" Width="80px" />
                <asp:Button ID="btnLimpiar" runat="server" Font-Bold="True" Font-Names="Arial" 
                    onclick="btnLimpiar_Click" Text="Limpiar" Width="80px" />
            </td>
            <td align="center">
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td align="center">
                <asp:Label runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text="Lista de Solicitudes"></asp:Label>
                <asp:GridView ID="grvSolicitudes" runat="server" Font-Bold="False" 
                    Font-Names="Arial" CellPadding="4" ForeColor="#333333" GridLines="None" 
                    onselectedindexchanged="grvSolicitudes_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#66FF99" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
            <td align="center">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text="Datos de Entidad"></asp:Label>
                <br />
                <asp:TextBox ID="txtEntidades" runat="server" Font-Bold="True" 
                    Font-Names="Arial" Height="70px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text="Datos de Tramite"></asp:Label>
                <br />
                <asp:TextBox ID="txtTramites" runat="server" Font-Bold="True" 
                    Font-Names="Arial" Height="70px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            </td>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td align="center" colspan="2">
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td align="center" colspan="2">
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Names="Arial" 
                    ForeColor="#FF3300"></asp:Label>
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
                    Font-Names="Arial" PostBackUrl="~/frmPrincipal.aspx">Inicio</asp:LinkButton>
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
    </table>
</asp:Content>

