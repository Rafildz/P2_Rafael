using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P2TalpRaf
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nome"] != null)
                lbl.Text = Session["nome"].ToString();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            
            P2WebApi.Models.Funcionarios funcionario = new P2WebApi.Models.Funcionarios();
            P2WebApi.Controllers.FuncionariosController func = new P2WebApi.Controllers.FuncionariosController();

            funcionario = func.ValidaSenha(int.Parse(textId.Text), textSenha.Text);
            if (funcionario != null)
            {
                Session.Add("nome", funcionario.Nome.ToString());
                //lbl.Text = funcionario.Nome.ToString();
                Response.Redirect("Login.aspx");
            }
            
        }
    }
}