using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoTeste.Util;

namespace ProjetoTeste.Pages
{
    public partial class Page_Login : System.Web.UI.Page
    {

        protected void AutenticarUsuario()
        {
            Response.Redirect("Page_Home.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (db_ProjetoTesteEntities ctx = new db_ProjetoTesteEntities())
            {
                // Recupere o login correspondente ao texto inserido pelo usuário
                var login = txtLogin.Text.Trim();
                var query = (from obj in ctx.tb_login
                             where obj.login == login
                             select obj).FirstOrDefault();

                // Verifique se o login foi encontrado
                if (query != null)
                {
                    // O login foi encontrado, você pode realizar ações aqui, como verificar a senha, etc.
                    // Por exemplo:
                    var senha = txtSenha.Text.Trim();
                    if (query.password == senha)
                    {
                        // A senha está correta, faça algo, como autenticar o usuário, redirecionar para outra página, etc.
                        // Por exemplo:
                        AutenticarUsuario();
                    }
                    else
                    {
                        // A senha está incorreta, informe ao usuário
                        // Por exemplo:
                        Framework.Alerta(Page, "Senha incorreta. Tente novamente.");
                    }
                }
                else
                {
                    // O login não foi encontrado, informe ao usuário
                    // Por exemplo:
                    Framework.Alerta(Page, "Login não encontrado. Verifique se o login está correto.");
                }
            }




        }
    }
}