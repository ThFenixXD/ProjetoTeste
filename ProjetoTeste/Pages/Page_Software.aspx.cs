using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoTeste.Util;

namespace ProjetoTeste.Pages
{
    public partial class Page_Software : System.Web.UI.Page
    {
        #region Métodos

        protected void PopulaDdlFabricante()
        {
            ddlFabricante.DataSource = Framework.GetDataTable("SELECT cdFabricante, fabricante FROM tb_fabricante WHERE deleted = 0");
            ddlFabricante.DataBind();
            ddlFabricante.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-- Selecione --"));

        }

        protected void LimpaCampos()
        {
            txtSoftware.Text =
            hdfId.Value = "";
            ddlFabricante.SelectedValue = "0";
        }

        protected void PopulaCampos(int _cdId)
        {
            using (db_ProjetoTesteEntities ctx = new db_ProjetoTesteEntities())
            {
                int cdId = _cdId;
                hdfId.Value = _cdId.ToString();

                var query = (from obj in ctx.tb_software
                             where obj.cdSoftware == cdId
                             select obj).FirstOrDefault();

                if (query != null)
                {
                    ddlFabricante.SelectedValue = query.cdFabricante.ToString();
                    txtSoftware.Text = query.software;
                }
                else
                {
                    Framework.Alerta(Page, "Erro ao preencher os campos!");
                }
            }
        }

        protected void AtualizaGrid()
        {
            GridSoftware.DataSource = Framework.GetDataTable("SELECT s.cdSoftware, s.software, f.cdFabricante, f.fabricante FROM tb_software AS s INNER JOIN tb_fabricante AS f ON s.cdFabricante = f.cdFabricante WHERE s.deleted = 0");
            GridSoftware.DataBind();
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulaDdlFabricante();
            }
        }

        protected void GridSoftware_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GridSoftware.DataSource = Framework.GetDataTable("SELECT s.cdSoftware, s.software, f.cdFabricante, f.fabricante FROM tb_software AS s INNER JOIN tb_fabricante AS f ON s.cdFabricante = f.cdFabricante WHERE s.deleted = 0");
        }

        protected void GridSoftware_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            int _cdID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["cdSoftware"]);

            switch (e.CommandName)
            {
                case "opEditar":
                    Framework.EscondePaineis(pnlSoftware);
                    pnlCadSoftware.Visible = true;
                    LimpaCampos();
                    PopulaCampos(_cdID);
                    break;

                case "opExcluir":

                    using (db_ProjetoTesteEntities ctx = new db_ProjetoTesteEntities())
                    {
                        var query = (from obj in ctx.tb_software
                                     where obj.cdSoftware == _cdID
                                     select obj).FirstOrDefault();

                        if (query != null)
                        {
                            query.deleted = 1;
                            ctx.SaveChanges();
                            AtualizaGrid();
                        }
                        else
                        {
                            Framework.Alerta(Page, "Falha ao excluir registro");
                        }
                    }
                    break;
            }
        }

        protected void btn_salvar_Click(object sender, EventArgs e)
        {
            using (db_ProjetoTesteEntities ctx = new db_ProjetoTesteEntities())
            {
                tb_software software = new tb_software();

                if (!string.IsNullOrEmpty(hdfId.Value))
                {
                    int cdId = Convert.ToInt32(hdfId.Value);

                    var query = (from obj in ctx.tb_software
                                 where obj.cdSoftware == cdId
                                 select obj);

                    if (query != null)
                    {
                        software = query.FirstOrDefault();
                    }
                }
                software.cdFabricante = Convert.ToInt32(ddlFabricante.SelectedValue);
                software.software = txtSoftware.Text.Trim();
                software.deleted = 0;

                if (string.IsNullOrEmpty(hdfId.Value))
                {
                    ctx.tb_software.Add(software);
                }

                ctx.SaveChanges();
                Framework.Alerta(Page, "Salvo com Sucesso!");
                Framework.EscondePaineis(pnlCadSoftware);
                LimpaCampos();
                pnlSoftware.Visible = true;
                AtualizaGrid();
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            Framework.EscondePaineis(pnlCadSoftware);
            pnlSoftware.Visible = true;
            AtualizaGrid();
        }

        protected void btn_cadastrar_Click(object sender, EventArgs e)
        {
            Framework.EscondePaineis(pnlSoftware);
            pnlCadSoftware.Visible = true;
            LimpaCampos();
        }

        protected void btn_voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page_Home.aspx");
        }
    }
}