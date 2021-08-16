<%@ Page Title="Detalle del Prospecto" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="DetalleProspecto.aspx.cs" Inherits="UI.DetalleProspecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td>
                <asp:Label runat="server" Text="Nombre del Prospecto:"></asp:Label>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:Label runat="server" Text="Primer Apellido:"></asp:Label>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:Label runat="server" Text="Segundo Apellido:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtProspecto" runat="server" MaxLength="80" Width="200px" ReadOnly="true"></asp:TextBox>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtApellido1" runat="server" MaxLength="80" Width="200px" ReadOnly="true"></asp:TextBox>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtApellido2" runat="server" MaxLength="80" Width="200px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Calle:"></asp:Label>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:Label runat="server" Text="Número:"></asp:Label>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:Label runat="server" Text="Colonia:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtCalle" runat="server" MaxLength="50" Width="200px" ReadOnly="true"></asp:TextBox>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtNumero" runat="server" MaxLength="10" TextMode="Number" Width="200px" ReadOnly="true"></asp:TextBox>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtColonia" runat="server" MaxLength="50" Width="200px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Código Postal:"></asp:Label>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:Label runat="server" Text="Teléfono:"></asp:Label>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:Label runat="server" Text="Rfc:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtCodigoPostal" runat="server" MaxLength="5" TextMode="Number" Width="200px" ReadOnly="true"></asp:TextBox>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server" MaxLength="10" TextMode="Number" Width="200px" ReadOnly="true"></asp:TextBox>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtRfc" runat="server" MaxLength="13" Width="200px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="pnlObserv" runat="server" Visible="false">
                    <asp:TextBox ID="txtObservaciones" runat="server" 
                        Width="100%" Height="100px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>                    
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:GridView ID="gvDocumentos" runat="server" 
                    AutoGenerateColumns="false" OnSelectedIndexChanged="gvDocumentos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Archivo" DataField="Archivo" />
                        <asp:BoundField HeaderText="Mime" DataField="Mime" />
                        <asp:ButtonField HeaderText="Acciones" CommandName="Select" Text="Seleccionar" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="pnlDescargar" runat="server" Visible="false">
                    <asp:Button ID="btnDescargar" 
                        runat="server" 
                        Text="Descargar" 
                        OnClick="btnDescargar_Click"  />
                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>
