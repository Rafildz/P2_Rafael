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
    public class VendasController : ApiController
    {
        private ConexaoPadrao db = new ConexaoPadrao();

        // GET: api/Vendas
        public IQueryable<Vendas> GetVendas()
        {
            return db.Vendas;
        }

        // GET: api/Vendas/5
        [ResponseType(typeof(Vendas))]
        public IHttpActionResult GetVendas(int id)
        {
            Vendas vendas = db.Vendas.Find(id);
            if (vendas == null)
            {
                return NotFound();
            }

            return Ok(vendas);
        }

        /// <summary>
        /// Metodo que busca todas as Vendas
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable BuscarTodosVendas()
        {
            SqlConnection conn = null;
            try
            {
                var stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();

                DataSet dtSet = new DataSet();
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                conn = new SqlConnection(stringConexao);
                conn.Open();

                dtAdapter.SelectCommand = new SqlCommand("SELECT IdVendas, Tipo, Descricao FROM Vendas ORDER BY IdVendas", conn);
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

        /// <summary>
        /// Metodo que Exclui uma venda
        /// </summary>
        /// <param name="vendas">Vendas</param>
        /// <returns>Boolean</returns>
        public Boolean ExcluirVendas(Vendas vendas)
        {
            SqlConnection conn = null;
            try
            {
                var stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();

                conn = new SqlConnection(stringConexao);
                conn.Open();

                SqlCommand _comand = new SqlCommand("DELETE FROM Vendas WHERE IdVendas like '@IdVendas'", conn);
                _comand.Parameters.AddWithValue("@IdVendas", vendas.IdVendas);
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
        /// Metodo que insere uma venda
        /// </summary>
        /// <param name="vendas">Vendas</param>
        /// <returns>Boolean</returns>
        public Boolean InsertVendas(Vendas vendas)
        {
            SqlConnection conn = null;
            try
            {
                var stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();

                conn = new SqlConnection(stringConexao);
                conn.Open();

                SqlCommand _comand = new SqlCommand("INSERT INTO Vendas (Tipo,Descricao) VALUES (@Tipo),(@Descricao)", conn);
                _comand.Parameters.AddWithValue("@Tipo", vendas.Tipo);
                _comand.Parameters.AddWithValue("@Descricao", vendas.Descricao);
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
        /// Metodo que atualiza dados da venda
        /// </summary>
        /// <param name="vendas">Vendas</param>
        /// <returns>Boolean</returns>
        public Boolean AtualizaVendas(Vendas vendas)
        {
            SqlConnection conn = null;
            try
            {
                var stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();

                conn = new SqlConnection(stringConexao);
                conn.Open();

                SqlCommand _comand = new SqlCommand("UPDATE Vendas SET Tipo = '@Tipo', Descricao = '@Descricao' WHERE IdVendas like '@IdVendas'", conn);
                _comand.Parameters.AddWithValue("@IdVendas", vendas.IdVendas);
                _comand.Parameters.AddWithValue("@Tipo", vendas.Tipo);
                _comand.Parameters.AddWithValue("@Descricao", vendas.Descricao);
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

        // PUT: api/Vendas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendas(int id, Vendas vendas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendas.IdVendas)
            {
                return BadRequest();
            }

            db.Entry(vendas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendasExists(id))
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

        // POST: api/Vendas
        [ResponseType(typeof(Vendas))]
        public IHttpActionResult PostVendas(Vendas vendas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vendas.Add(vendas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vendas.IdVendas }, vendas);
        }

        // DELETE: api/Vendas/5
        [ResponseType(typeof(Vendas))]
        public IHttpActionResult DeleteVendas(int id)
        {
            Vendas vendas = db.Vendas.Find(id);
            if (vendas == null)
            {
                return NotFound();
            }

            db.Vendas.Remove(vendas);
            db.SaveChanges();

            return Ok(vendas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendasExists(int id)
        {
            return db.Vendas.Count(e => e.IdVendas == id) > 0;
        }
    }
}