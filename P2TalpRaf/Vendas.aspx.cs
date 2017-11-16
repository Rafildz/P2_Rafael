using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P2TalpRaf
{
    public partial class Vendas : System.Web.UI.Page
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
            P2WebApi.Models.Vendas vendas = new P2WebApi.Models.Vendas();
            P2WebApi.Controllers.VendasController vd = new P2WebApi.Controllers.VendasController();
            this.grdCustosDespesas.DataSource = vd.BuscarTodosVendas();
            this.grdCustosDespesas.DataBind();
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            P2WebApi.Models.Vendas vendas = new P2WebApi.Models.Vendas();
            P2WebApi.Controllers.VendasController vd = new P2WebApi.Controllers.VendasController();
            vendas.Tipo = TextTipo.Text;
            vendas.Descricao = TextDescricao.Text;

            if (vd.InsertVendas(vendas))
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
            P2WebApi.Models.Vendas vendas = new P2WebApi.Models.Vendas();
            P2WebApi.Controllers.VendasController vd = new P2WebApi.Controllers.VendasController();
            vendas.IdVendas = int.Parse(TextID.Text);

            if (vd.ExcluirVendas(vendas))
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
            P2WebApi.Models.Vendas vendas = new P2WebApi.Models.Vendas();
            P2WebApi.Controllers.VendasController vd = new P2WebApi.Controllers.VendasController();
            vendas.IdVendas = int.Parse(TextID.Text);
            vendas.Tipo = TextTipo.Text;
            vendas.Descricao = TextDescricao.Text;
            if (vd.AtualizaVendas(vendas))
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