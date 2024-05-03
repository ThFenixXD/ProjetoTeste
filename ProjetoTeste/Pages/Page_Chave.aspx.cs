using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoTeste.Util;

namespace ProjetoTeste.Pages
{
    public partial class Page_Chave : System.Web.UI.Page
    {
        #region Métodos

        protected void LimpaCampos()
        {
            txtLicenca.Text =
            hdfId.Value = "";
            ddlFabricante.DataBind();
            ddlSoftware.DataBind();
            ddlTecnologia.DataBind();
        }

        protected void PopulaCampos(int _cdId)
        {
            using (db_ProjetoTesteEntities ctx = new db_ProjetoTesteEntities())
            {

                int cdId = _cdId;
                hdfId.Value = _cdId.ToString();

                var query = (from obj in ctx.tb_chave
                             where obj.cdChave == cdId
                             select obj).FirstOrDefault();

                txtLicenca.Text = query.licenca;
                ddlFabricante.SelectedValue = query.cdFabricante.ToString();
                ddlSoftware.SelectedValue = query.cdSoftware.ToString();
                ddlTecnologia.SelectedValue = query.cdTecnologia.ToString();
                txtChave.Text = query.chave.ToString();
            }
        }

        protected void PopulaDdlFabricante()
        {
            ddlFabricante.DataSource = Framework.GetDataTable("SELECT cdFabricante, fabricante FROM tb_fabricante WHERE deleted = 0");
            ddlFabricante.DataBind();
            ddlFabricante.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-- Selecione --"));
        }

        protected void PopulaDdlSoftwareId(int _cdId)
        {
            int cdId = _cdId;
            ddlSoftware.DataSource = Framework.GetDataTable($"SELECT s.cdSoftware, s.software, f.cdFabricante, f.fabricante FROM tb_software AS s  INNER JOIN tb_fabricante AS f ON s.cdFabricante = f.cdFabricante WHERE f.cdFabricante = {cdId} AND s.deleted = 0");
            ddlSoftware.DataBind();
        }

        protected void PopulaDdlTecnologia()
        {
            ddlTecnologia.DataSource = Framework.GetDataTable("SELECT cdTecnologia, tecnologia FROM tb_tecnologia WHERE deleted = 0");
            ddlTecnologia.DataBind();
            ddlTecnologia.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("-- Selecione --"));
        }

        protected void AtualizaGrid()
        {
            GridChave.DataSource = Framework.GetDataTable("SELECT c.cdChave, f.cdFabricante, f.fabricante, s.cdSoftware, s.software, t.cdTecnologia, t.tecnologia, c.licenca, c.chave FROM tb_chave AS c INNER JOIN tb_fabricante AS f ON f.cdFabricante = c.cdFabricante INNER JOIN tb_software AS s ON s.cdSoftware = c.cdSoftware INNER JOIN tb_tecnologia AS t ON t.cdTecnologia = c.cdTecnologia WHERE c.deleted = 0");
            GridChave.DataBind();
        }

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulaDdlFabricante();
                PopulaDdlTecnologia();
            }
        }
        #endregion

        #region SelectedIndexChanged
        protected void ddlFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulaDdlSoftwareId(Convert.ToInt32(ddlFabricante.SelectedValue));
        }
        #endregion

        #region Click
        protected void btn_salvar_Click(object sender, EventArgs e)
        {
            using (db_ProjetoTesteEntities ctx = new db_ProjetoTesteEntities())
            {
                tb_chave chave = new tb_chave();

                if (!string.IsNullOrEmpty(hdfId.Value))
                {
                    int cdId = Convert.ToInt32(hdfId.Value);

                    var query = (from obj in ctx.tb_chave
                                 where obj.cdChave == cdId
                                 select obj);

                    if (query != null)
                    {
                        chave = query.FirstOrDefault();
                    }
                }
                chave.cdFabricante = Convert.ToInt32(ddlFabricante.SelectedValue);
                chave.cdSoftware = Convert.ToInt32(ddlSoftware.SelectedValue);
                chave.cdTecnologia = Convert.ToInt32(ddlTecnologia.SelectedValue);
                chave.licenca = txtLicenca.Text.Trim();
                chave.chave = txtChave.Text.Trim();
                chave.deleted = 0;

                if (string.IsNullOrEmpty(hdfId.Value))
                {
                    ctx.tb_chave.Add(chave);
                }

                ctx.SaveChanges();
                Framework.Alerta(Page, "Salvo com Sucesso!");
                Framework.EscondePaineis(pnlCadChave);
                LimpaCampos();
                pnlChave.Visible = true;
                AtualizaGrid();
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            pnlCadChave.Visible = false;
            pnlChave.Visible = true;
            AtualizaGrid();
        }

        protected void btn_cadastrar_Click(object sender, EventArgs e)
        {
            Framework.EscondePaineis(pnlChave);
            pnlCadChave.Visible = true;
            LimpaCampos();
        }

        protected void btn_voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page_Home.aspx");
        }
        #endregion

        #region NeedDataSource
        protected void GridChave_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GridChave.DataSource = Framework.GetDataTable("SELECT c.cdChave, f.cdFabricante, f.fabricante, s.cdSoftware, s.software, t.cdTecnologia, t.tecnologia, c.licenca, c.chave FROM tb_chave AS c INNER JOIN tb_fabricante AS f ON f.cdFabricante = c.cdFabricante INNER JOIN tb_software AS s ON s.cdSoftware = c.cdSoftware INNER JOIN tb_tecnologia AS t ON t.cdTecnologia = c.cdTecnologia WHERE c.deleted = 0");
        }
        #endregion

        #region ItemCommand
        protected void GridChave_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            int _cdID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["cdChave"]);

            switch (e.CommandName)
            {
                case "opEditar":
                    Framework.EscondePaineis(pnlChave);
                    pnlCadChave.Visible = true;
                    LimpaCampos();
                    PopulaCampos(_cdID);
                    break;

                case "opExcluir":

                    using (db_ProjetoTesteEntities ctx = new db_ProjetoTesteEntities())
                    {
                        var query = (from obj in ctx.tb_chave
                                     where obj.cdChave == _cdID
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
        #endregion
    }
}