<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Default.Master" AutoEventWireup="true" CodeBehind="Page_Software.aspx.cs" Inherits="ProjetoTeste.Pages.Page_Software" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlCadSoftware" CssClass="pnlCad" runat="server" Visible="false">

        <h2 class="title_cad">Cadastro Software</h2>
        
                <div class="pnlCad_info">
                    <asp:Label ID="lbFabricante" CssClass="lb" runat="server" Text="Fabricante"></asp:Label>
                    <telerik:RadComboBox ID="ddlFabricante" Style="margin: auto 0 auto 1em;" runat="server" DataTextField="fabricante" DataValueField="cdFabricante"></telerik:RadComboBox>

                    <asp:Label ID="lbSoftware" CssClass="lb" Style="margin: auto 0 auto 1em;" runat="server" Text="Software"></asp:Label>
                    <telerik:RadTextBox ID="txtSoftware" CssClass="txt" Style="margin: auto 0 auto 1em;" Width="75%" runat="server"></telerik:RadTextBox>
                </div>
       


        <div class="pnlCad_BoxButton" runat="server">
            <asp:Button ID="btn_salvar" runat="server" Text="Salvar" OnClick="btn_salvar_Click" />
            <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" />
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlSoftware" CssClass="pnlGrid" runat="server">
        <div class="pnl_BoxButton" runat="server">
            <asp:Button ID="btn_cadastrar" runat="server" Text="Cadastrar" OnClick="btn_cadastrar_Click" />
            <asp:Button ID="btn_voltar" runat="server" Text="Voltar" OnClick="btn_voltar_Click" />
        </div>

        <telerik:RadGrid
            ID="GridSoftware"
            CssClass="GridList"
            runat="server"
            AutoGenerateColumns="false"
            OnNeedDataSource="GridSoftware_NeedDataSource"
            OnItemCommand="GridSoftware_ItemCommand">

            <GroupingSettings CollapseAllTooltip="collapse all columns" />

            <MasterTableView DataKeyNames="cdSoftware">
                <Columns>
                    <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="op" ItemStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Button ID="btn_editar" runat="server" Text="Editar" CommandName="opEditar" />
                            <asp:Button ID="btn_excluir" runat="server" Text="Excluir" CommandName="opExcluir" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn
                        UniqueName="ColumnCod"
                        DataField="cdFabricante"
                        HeaderText="COD"
                        HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Font-Bold="true"
                        ItemStyle-HorizontalAlign="Center"
                        ItemStyle-Width="5%">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn
                        UniqueName="ColumnFabricante"
                        DataField="fabricante"
                        HeaderText="FABRICANTE"
                        HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Font-Bold="true"
                        ItemStyle-HorizontalAlign="Center"
                        ItemStyle-Width="15%">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn
                        UniqueName="ColumnSoftware"
                        DataField="software"
                        HeaderText="SOFTWARE"
                        HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Font-Bold="true"
                        ItemStyle-HorizontalAlign="Center">
                    </telerik:GridBoundColumn>
                </Columns>

            </MasterTableView>
        </telerik:RadGrid>
    </asp:Panel>
    <asp:HiddenField ID="hdfId" runat="server" />
</asp:Content>
