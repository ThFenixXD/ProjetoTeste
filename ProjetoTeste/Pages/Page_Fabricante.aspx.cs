using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoTeste.Util;

namespace ProjetoTeste.Pages
{
    public partial class Page_Fabricante : System.Web.UI.Page
    {
        #region Métodos

        protected void LimpaCampos()
        {
            txtFabricante.Text =
            hdfId.Value = "";
        }

        protected void PopulaCampos(int _cdId)
        {
            int cdId = _cdId;
            hdfId.Value = _cdId.ToString();

            using (db_ProjetoTesteEntities ctx = new db_ProjetoTesteEntities())
            {
                var query = (from obj in ctx.tb_fabricante
                             where obj.cdFabricante == cdId
                             select obj).FirstOrDefault();

                if (query != null)
                {
                    txtFabricante.Text = query.fabricante;
                }
                else
                {
                    Framework.Alerta(Page, "Erro ao consultar o banco de dados");
                }
            }

        }

        protected void AtualizaGrid()
        {
            GridFabricante.DataSource = Framework.GetDataTable("SELECT cdFabricante, fabricante FROM tb_fabricante WHERE deleted = 0");
            GridFabricante.DataBind();
        }

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region NeedDataSource
        protected void GridFabricante_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GridFabricante.DataSource = Framework.GetDataTable("SELECT cdFabricante, fabricante FROM tb_fabricante WHERE deleted = 0");
        }
        #endregion

        #region ItemCommand
        protected void GridFabricante_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            int _cdID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["cdFabricante"]);

            switch (e.CommandName)
            {
                case "opEditar":
                    Framework.EscondePaineis(pnlFabricante);
                    pnlCadFabricante.Visible = true;
                    LimpaCampos();
                    PopulaCampos(_cdID);
                    break;

                case "opExcluir":

                    using (db_ProjetoTesteEntities ctx = new db_ProjetoTesteEntities())
                    {
                        var query = (from obj in ctx.tb_fabricante
                                     where obj.cdFabricante == _cdID
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

        #region Click
        protected void btn_salvar_Click(object sender, EventArgs e)
        {
            using (db_ProjetoTesteEntities ctx = new db_ProjetoTesteEntities())
            {
                tb_fabricante fabricante = new tb_fabricante();

                if (!string.IsNullOrEmpty(hdfId.Value))
                {
                    int cdId = Convert.ToInt32(hdfId.Value);

                    var query = (from obj in ctx.tb_fabricante
                                 where obj.cdFabricante == cdId
                                 select obj);

                    if (query != null)
                    {
                        fabricante = query.FirstOrDefault();
                    }
                }
                fabricante.fabricante = txtFabricante.Text.Trim();
                fabricante.deleted = 0;

                if (string.IsNullOrEmpty(hdfId.Value))
                {
                    ctx.tb_fabricante.Add(fabricante);
                }

                ctx.SaveChanges();
                Framework.Alerta(Page, "Salvo com Sucesso!");
                Framework.EscondePaineis(pnlCadFabricante);
                LimpaCampos();
                pnlFabricante.Visible = true;
                AtualizaGrid();
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            Framework.EscondePaineis(pnlCadFabricante);
            pnlFabricante.Visible = true;
            AtualizaGrid();
        }

        protected void btn_cadastrar_Click(object sender, EventArgs e)
        {
            Framework.EscondePaineis(pnlFabricante);
            pnlCadFabricante.Visible = true;
            LimpaCampos();
        }

        protected void btn_voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page_Home.aspx");
        }
        #endregion
    }
}