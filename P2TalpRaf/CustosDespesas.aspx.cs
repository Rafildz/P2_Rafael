using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P2TalpRaf
{
    public partial class CustosDespesas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PreencherGrid();
            }
        }

        private void PreencherGrid()
        {
            P2WebApi.Models.CustosDespesas custosDespesas = new P2WebApi.Models.CustosDespesas();
            P2WebApi.Controllers.CustosDespesasController cd = new P2WebApi.Controllers.CustosDespesasController();
            this.grdCustosDespesas.DataSource = cd.BuscarTodosCustosDespesas();
            this.grdCustosDespesas.DataBind();
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            P2WebApi.Models.CustosDespesas custDesp = new P2WebApi.Models.CustosDespesas();
            P2WebApi.Controllers.CustosDespesasController cd = new P2WebApi.Controllers.CustosDespesasController();
            custDesp.Tipo = TextTipo.Text;
            custDesp.Descricao = TextDescricao.Text;

            if (cd.InsertCustosDespesas(custDesp))
            {
                this.Label.Text = "Inserido com sucesso";
                this.PreencherGrid();
            }
            else
            {
                this.Label.Text = "Erro na insercao";
            }
        }

        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            P2WebApi.Models.CustosDespesas custDesp = new P2WebApi.Models.CustosDespesas();
            P2WebApi.Controllers.CustosDespesasController cd = new P2WebApi.Controllers.CustosDespesasController();
            custDesp.IdCD = int.Parse(TextID.Text);

            if (cd.ExcluirCustosDespesas(custDesp))
            {
                this.Label.Text = "Deletado com sucesso";
                this.PreencherGrid();
            }
            else
            {
                this.Label.Text = "Erro ao deletar";
            }

        }

        protected void ButtonAtualizar_Click(object sender, EventArgs e)
        {
            P2WebApi.Models.CustosDespesas custDesp = new P2WebApi.Models.CustosDespesas();
            P2WebApi.Controllers.CustosDespesasController cd = new P2WebApi.Controllers.CustosDespesasController();
            custDesp.IdCD = int.Parse(TextID.Text);
            custDesp.Tipo = TextTipo.Text;
            custDesp.Descricao = TextDescricao.Text;
            if (cd.AtualizaCustosDespesas(custDesp))
            {
                this.Label.Text = "Atualizado com sucesso";
                this.PreencherGrid();
            }
            else
            {
                this.Label.Text = "Erro ao atualizar";
            }

        }
    }
}