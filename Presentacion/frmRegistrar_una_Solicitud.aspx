<%@ Page Title="" Language="C#" MasterPageFile="~/mpUsuario.master" AutoEventWireup="true" CodeFile="frmRegistrar_una_Solicitud.aspx.cs" Inherits="frmRegistrar_una_Solicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="X-Large" Text="Registrar Solicitud"></asp:Label>
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
            <td align="center" rowspan="4">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text="Lista de Tramites"></asp:Label>
                <asp:GridView ID="grvLista_de_Tramites" runat="server" Font-Bold="False" 
                    Font-Names="Arial" 
                    onselectedindexchanged="grvLista_de_Tramites_SelectedIndexChanged" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
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
            <td align="center" rowspan="2">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text="Tramite Seleccionado"></asp:Label>
                <br />
                <asp:TextBox ID="txtDetalles" runat="server" Height="70px" Width="200px" 
                    TextMode="MultiLine"></asp:TextBox>
                <br />
                <br />
                <asp:Calendar ID="cldFecha" runat="server" BackColor="White" 
                    BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                    ForeColor="Black" Height="186px" NextPrevFormat="FullMonth" Width="200px" 
                    CaptionAlign="Right">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                        VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="White" BorderWidth="4px" 
                        Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text="Hora:   "></asp:Label>
                <asp:TextBox ID="txtHora" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Width="50px"></asp:TextBox>
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text=":"></asp:Label>
                <asp:TextBox ID="txtMinutos" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Width="50px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Text="Solicitante:   "></asp:Label>
                <asp:TextBox ID="txtNombre_Solicitante" runat="server" Font-Bold="True" 
                    Font-Names="Arial" Width="200px"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Button ID="btnLimpiar" runat="server" Font-Bold="True" 
                    onclick="btnLimpiar_Click" Text="Limpiar" Width="70px" />
                <asp:Button ID="btnRegistrar_Solicitud" runat="server" Font-Bold="True" 
                    Font-Names="Arial" Text="Registrar" 
                    onclick="btnRegistrar_Solicitud_Click" Width="70px" />
                <br />
                <br />
                <br />
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Names="Arial" 
                    ForeColor="Red"></asp:Label>
                <br />
                <br />
                <asp:LinkButton ID="lbtnVolver" runat="server" Font-Bold="True" 
                    Font-Names="Arial" PostBackUrl="~/frmPrincipal.aspx">Volver</asp:LinkButton>
            </td>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td align="center">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
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
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

