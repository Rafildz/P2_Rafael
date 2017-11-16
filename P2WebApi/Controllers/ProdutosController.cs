using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using P2WebApi.DAL;
using P2WebApi.Models;
using System.Data.SqlClient;

namespace P2WebApi.Controllers
{
    public class ProdutosController : ApiController
    {
        private ConexaoPadrao db = new ConexaoPadrao();

        // GET: api/Produtos
        public IQueryable<Produtos> GetProdutos()
        {
            return db.Produtos;
        }

        // GET: api/Produtos/5
        [ResponseType(typeof(Produtos))]
        public IHttpActionResult GetProdutos(int id)
        {
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return NotFound();
            }

            return Ok(produtos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object BuscarTodosProdutos()
        {
            SqlConnection conn = null;
            try
            {
                var stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();

                DataSet dtSet = new DataSet();
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                conn = new SqlConnection(stringConexao);
                conn.Open();

                dtAdapter.SelectCommand = new SqlCommand("SELECT IdProdutos, Quantidade, Preco, Nome, Tipo, Descricao FROM Produtos ORDER BY IdProdutos", conn);
                dtAdapter.Fill(dtSet);

                return dtSet.Tables[0];

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        // PUT: api/Produtos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProdutos(int id, Produtos produtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produtos.IdProduto)
            {
                return BadRequest();
            }

            db.Entry(produtos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produtos"></param>
        /// <returns></returns>
        public bool InsertProdutos(Produtos produtos)
        {
            SqlConnection conn = null;
            try
            {
                var stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();

                conn = new SqlConnection(stringConexao);
                conn.Open();

                SqlCommand _comand = new SqlCommand("INSERT INTO Produtos (Quantidade,Preco,Nome,Tipo,Descricao) VALUES (@Quantidade),(@Preco),(@Nome),(@Tipo),(@Descricao)", conn);
                _comand.Parameters.AddWithValue("@Quantidade", produtos.Quantidade);
                _comand.Parameters.AddWithValue("@Preco", produtos.Preco);
                _comand.Parameters.AddWithValue("@Nome", produtos.Nome);
                _comand.Parameters.AddWithValue("@Tipo", produtos.Tipo);
                _comand.Parameters.AddWithValue("@Descricao", produtos.Descricao);
                _comand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produtos"></param>
        /// <returns></returns>
        public bool ExcluirProdutos(Produtos produtos)
        {
            SqlConnection conn = null;
            try
            {
                var stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();

                conn = new SqlConnection(stringConexao);
                conn.Open();

                SqlCommand _comand = new SqlCommand("DELETE FROM Produtos WHERE IdProdutos like '@IdProdutos'", conn);
                _comand.Parameters.AddWithValue("@IdProdutos", produtos.IdProduto);
                _comand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        // POST: api/Produtos
        [ResponseType(typeof(Produtos))]
        public IHttpActionResult PostProdutos(Produtos produtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Produtos.Add(produtos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produtos.IdProduto }, produtos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produtos"></param>
        /// <returns></returns>
        public bool AtualizaProdutos(Produtos produtos)
        {
            SqlConnection conn = null;
            try
            {
                var stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();

                conn = new SqlConnection(stringConexao);
                conn.Open();

                SqlCommand _comand = new SqlCommand("UPDATE Produtos SET Quantidade='@Quantidade', Preco='@Preco', Nome='@Nome', Tipo='@Tipo', Descricao='@Descricao' WHERE IdProdutos like '@IdProdutos'", conn);
                _comand.Parameters.AddWithValue("@IdProdutos", produtos.IdProdutos);
                _comand.Parameters.AddWithValue("@Quantidade", produtos.Quantidade);
                _comand.Parameters.AddWithValue("@Preco", produtos.Preco);
                _comand.Parameters.AddWithValue("@Nome", produtos.Nome);
                _comand.Parameters.AddWithValue("@Tipo", produtos.Tipo);
                _comand.Parameters.AddWithValue("@Descricao", produtos.Descricao);
                _comand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        // DELETE: api/Produtos/5
        [ResponseType(typeof(Produtos))]
        public IHttpActionResult DeleteProdutos(int id)
        {
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return NotFound();
            }

            db.Produtos.Remove(produtos);
            db.SaveChanges();

            return Ok(produtos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutosExists(int id)
        {
            return db.Produtos.Count(e => e.IdProduto == id) > 0;
        }
    }
}