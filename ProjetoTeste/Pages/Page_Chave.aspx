<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Default.Master" AutoEventWireup="true" CodeBehind="Page_Chave.aspx.cs" Inherits="ProjetoTeste.Pages.Page_Chave" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlCadChave" CssClass="pnlCad" runat="server" Visible="false">
                <div class="pnlCad_info d-flex flex-column">
                    <div class="pnlCad_info_box">
                        <asp:Label ID="lbFabricante" CssClass="lb col-2 col-md-2 col-sm-2" runat="server" Text="Fabricante"></asp:Label>
                        <telerik:RadComboBox ID="ddlFabricante" Style="margin: auto 0 auto 1em;" Width="100%" runat="server" DataTextField="fabricante" DataValueField="cdFabricante" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlFabricante_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </div>

                    <div class="pnlCad_info_box">
                        <asp:Label ID="lbSoftware" CssClass="lb col-2 col-md-2 col-sm-2" runat="server" Text="Software"></asp:Label>
                        <telerik:RadComboBox ID="ddlSoftware" Style="margin: auto 0 auto 1em;" Width="100%" runat="server" DataTextField="software" DataValueField="cdSoftware"></telerik:RadComboBox>
                    </div>

                    <div class="pnlCad_info_box">
                        <asp:Label ID="lbTecnologia" CssClass="lb col-2 col-md-2 col-sm-2" runat="server" Text="Tecnologia"></asp:Label>
                        <telerik:RadComboBox ID="ddlTecnologia" Style="margin: auto 0 auto 1em;" Width="100%" runat="server" DataTextField="tecnologia" DataValueField="cdTecnologia"></telerik:RadComboBox>
                    </div>

                    <div class="pnlCad_info_box">
                        <asp:Label ID="lbLicenca" CssClass="lb col-2 col-md-2 col-sm-2" runat="server" Text="Licença"></asp:Label>
                        <telerik:RadTextBox ID="txtLicenca" Style="margin: auto 0 auto 1em;" Width="100%" runat="server" PlaceHolder="Exemplo: (Perpétua) / (Temporária 30 Dias)"></telerik:RadTextBox>
                    </div>

                    <div class="pnlCad_info_box">
                        <asp:Label ID="lbChave" CssClass="lb col-2 col-md-2 col-sm-2" runat="server" Text="Chave"></asp:Label>
                        <telerik:RadTextBox ID="txtChave" Style="margin: auto 0 auto 1em;" Width="100%" runat="server" PlaceHolder="XXXXX-XXXXX-XXXXX-XXXXX-XXXXX"></telerik:RadTextBox>
                    </div>
                </div>
                <div class="pnlCad_BoxButton" runat="server">
                    <asp:Button ID="btn_salvar" runat="server" Text="Salvar" OnClick="btn_salvar_Click" />
                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" />
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlChave" CssClass="pnlGrid" runat="server">
                <div class="pnl_BoxButton" runat="server">
                    <asp:Button ID="btn_cadastrar" runat="server" Text="Cadastrar" OnClick="btn_cadastrar_Click" />
                    <asp:Button ID="btn_voltar" runat="server" Text="Voltar" OnClick="btn_voltar_Click" />
                </div>

                <telerik:RadGrid
                    ID="GridChave"
                    CssClass="GridList"
                    runat="server"
                    AutoGenerateColumns="false"
                    OnNeedDataSource="GridChave_NeedDataSource"
                    OnItemCommand="GridChave_ItemCommand">

                    <GroupingSettings CollapseAllTooltip="collapse all columns" />

                    <MasterTableView DataKeyNames="cdChave">
                        <Columns>
                            <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="op" ItemStyle-Width="15%">
                                <ItemTemplate>
                                    <asp:Button ID="btn_editar" runat="server" Text="Editar" CommandName="opEditar" />
                                    <asp:Button ID="btn_excluir" runat="server" Text="Excluir" CommandName="opExcluir" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn
                                UniqueName="ColumnCod"
                                DataField="cdChave"
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
                                ItemStyle-HorizontalAlign="Center">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn
                                UniqueName="ColumnSoftware"
                                DataField="software"
                                HeaderText="SOFTWARE"
                                HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-Font-Bold="true"
                                ItemStyle-HorizontalAlign="Center">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn
                                UniqueName="ColumnTecnologia"
                                DataField="tecnologia"
                                HeaderText="TECNOLOGIA"
                                HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-Font-Bold="true"
                                ItemStyle-HorizontalAlign="Center">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn
                                UniqueName="ColumnLicenca"
                                DataField="licenca"
                                HeaderText="LICENÇA"
                                HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-Font-Bold="true"
                                ItemStyle-HorizontalAlign="Center">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn
                                UniqueName="Columnchave"
                                DataField="chave"
                                HeaderText="CHAVE"
                                HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-Font-Bold="true"
                                ItemStyle-HorizontalAlign="Center">
                            </telerik:GridBoundColumn>
                        </Columns>

                    </MasterTableView>
                </telerik:RadGrid>
            </asp:Panel>
            <asp:HiddenField ID="hdfId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
