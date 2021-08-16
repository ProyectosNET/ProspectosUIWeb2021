<%@ Page Title="Captura de Prospecto" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CapturaDeProspecto.aspx.cs" Inherits="UI.CapturaDeProspecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>

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
                <asp:TextBox ID="txtProspecto" runat="server" MaxLength="80" Width="200px" CssClass="UpperCase"></asp:TextBox>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtApellido1" runat="server" MaxLength="80" Width="200px" CssClass="UpperCase"></asp:TextBox>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtApellido2" runat="server" MaxLength="80" Width="200px" CssClass="UpperCase"></asp:TextBox>
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
                <asp:TextBox ID="txtCalle" runat="server" MaxLength="50" Width="200px" CssClass="UpperCase"></asp:TextBox>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtNumero" runat="server" MaxLength="10" TextMode="Number" Width="200px"></asp:TextBox>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtColonia" runat="server" MaxLength="50" Width="200px" CssClass="UpperCase"></asp:TextBox>
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
                <asp:TextBox ID="txtCodigoPostal" runat="server" MaxLength="5" TextMode="Number" Width="200px"></asp:TextBox>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server" MaxLength="10" TextMode="Number" Width="200px"></asp:TextBox>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtRfc" runat="server" MaxLength="13" Width="200px" CssClass="UpperCase"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label runat="server" Text="Subir Documentación:"></asp:Label>
            </td>
        </tr>
    </table>

    <table style="margin-top: 8px;">
        <tr>
            <td>
                <asp:TextBox ID="txtNombreDoc" runat="server" MaxLength="50" Width="200px" CssClass="UpperCase"></asp:TextBox>
            </td>
            <asp:UpdatePanel ID="upanel" runat="server">
                <ContentTemplate>
                    <td style="width: 8px;">
                        <asp:FileUpload ID="upload" runat="server" AllowMultiple="true" />
                    </td>
                    <td>
                        <asp:Button ID="btnUpload" runat="server" Text="Subir" OnClick="btnUpload_Click" />
                    </td>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnUpload" />
                </Triggers>
            </asp:UpdatePanel>
        </tr>
    </table>

    <script type="text/javascript">
        function Salir() {
            var result = confirm('¿Está seguro de salir de la captura, se perderá toda la información?');
            if (result) {
                window.location = '/Inicio.aspx';
            }
        }
    </script>

    <table style="margin-top: 8px;">
        <tr>
            <td>
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClientClick="Salir();" />
            </td>
        </tr>
    </table>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
