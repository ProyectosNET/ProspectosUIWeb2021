<%@ Page Title="Evaluación del Prospecto" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="EvaluacionDelProspecto.aspx.cs" Inherits="UI.EvaluacionDelProspecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="up2" runat="server">
        <ContentTemplate>

    <asp:Panel ID="pnlGrid" runat="server">
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
                            <asp:BoundField HeaderText="Rfc" DataField="Rfc" />
                            <asp:BoundField HeaderText="Estatus" DataField="Status" />
                            <asp:ButtonField HeaderText="Acciones" CommandName="Select" Text="Autorizar o Rechazar" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="template" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    <asp:RadioButton ID="rbA" runat="server" Text="Autorizar" Checked="true" GroupName="rbEstatus" OnCheckedChanged="rbA_CheckedChanged" AutoPostBack="true" />
                </td>
                <td style="width: 8px;"></td>
                <td>
                    <asp:RadioButton ID="rbR" runat="server" Text="Rechazar" GroupName="rbEstatus" OnCheckedChanged="rbR_CheckedChanged" AutoPostBack="true" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="pnlObserv" runat="server" Visible="false">
                        <asp:TextBox ID="txtObservaciones" runat="server" MaxLength="300" CssClass="UpperCase"
                            Width="200px" Height="200px" TextMode="MultiLine"></asp:TextBox>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <table style="margin-top: 8px;">
            <tr>
                <td>
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                </td>
                <td style="width: 8px;"></td>
                <td>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
