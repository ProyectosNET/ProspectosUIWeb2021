<%@ Page Title="Listado de Prospectos" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListadoDeProspectos.aspx.cs" Inherits="UI.ListadoDeProspectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="up3" runat="server">
        <ContentTemplate>

    <table>
        <tr>
            <td>
                <asp:GridView ID="gvProspectos" runat="server" 
                    AutoGenerateColumns="false" 
                    OnSelectedIndexChanged="gvProspectos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido Paterno" DataField="ApellidoPaterno" />
                        <asp:BoundField HeaderText="Apellido Materno" DataField="ApellidoMaterno" />
                        <asp:BoundField HeaderText="Estatus" DataField="Status" />
                        <asp:ButtonField HeaderText="Acciones" CommandName="Select" Text="Ver Detalle" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
