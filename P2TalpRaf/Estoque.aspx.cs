using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P2TalpRaf
{
    public partial class Estoque : System.Web.UI.Page
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
            P2WebApi.Models.Produtos produtos = new P2WebApi.Models.Produtos();
            P2WebApi.Controllers.ProdutosController pr = new P2WebApi.Controllers.ProdutosController();
            this.grdCustosDespesas.DataSource = pr.BuscarTodosProdutos();
            this.grdCustosDespesas.DataBind();
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            P2WebApi.Models.Produtos produtos = new P2WebApi.Models.Produtos();
            P2WebApi.Controllers.ProdutosController pr = new P2WebApi.Controllers.ProdutosController();
            produtos.Quantidade = int.Parse(TextQuantidade.Text);
            produtos.Preco = float.Parse(TextPreco.Text);
            produtos.Nome = TextNome.Text;
            produtos.Tipo = TextTipo.Text;
            produtos.Descricao = TextDescricao.Text;

            if (pr.InsertProdutos(produtos))
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
            P2WebApi.Models.Produtos produtos = new P2WebApi.Models.Produtos();
            P2WebApi.Controllers.ProdutosController pr = new P2WebApi.Controllers.ProdutosController();
            produtos.IdProduto = int.Parse(TextID.Text);

            if (pr.ExcluirProdutos(produtos)
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
            P2WebApi.Models.Produtos produtos = new P2WebApi.Models.Produtos();
            P2WebApi.Controllers.ProdutosController pr = new P2WebApi.Controllers.ProdutosController();
            produtos.IdProduto = int.Parse(TextID.Text);
            produtos.Quantidade = int.Parse(TextQuantidade.Text);
            produtos.Preco = float.Parse(TextPreco.Text);
            produtos.Nome = TextNome.Text;
            produtos.Tipo = TextTipo.Text;
            produtos.Descricao = TextDescricao.Text;
            if (pr.AtualizaProdutos(produtos))
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