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
    public class CustosDespesasController : ApiController
    {
        private ConexaoPadrao db = new ConexaoPadrao();

        // GET: api/CustosDespesas
        public IQueryable<CustosDespesas> GetCustosDespesas()
        {
            return db.CustosDespesas;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable BuscarTodosCustosDespesas()
        {
            SqlConnection conn = null;
            try
            {
                var stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();

                DataSet dtSet = new DataSet();
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                conn = new SqlConnection(stringConexao);
                conn.Open();

                dtAdapter.SelectCommand = new SqlCommand("SELECT IdCD, Tipo, Descricao FROM CustosDespesas ORDER BY IdCD", conn);
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
        /// 
        /// </summary>
        /// <param name="cd"></param>
        /// <returns></returns>
        public Boolean InsertCustosDespesas(CustosDespesas cd)
        {
            SqlConnection conn = null;
            try
            {
                var stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();

                conn = new SqlConnection(stringConexao);
                conn.Open();

                SqlCommand _comand = new SqlCommand("INSERT INTO CustosDespesas (Tipo,Descricao) VALUES (@Tipo), (@Descricao)", conn);
                _comand.Parameters.AddWithValue("@Tipo", cd.Tipo);
                _comand.Parameters.AddWithValue("@Descricao", cd.Descricao);
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
        /// <param name="custDesp"></param>
        /// <returns></returns>
        public bool AtualizaCustosDespesas(CustosDespesas custDesp)
        {
            SqlConnection conn = null;
            try
            {
                var stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();

                conn = new SqlConnection(stringConexao);
                conn.Open();

                SqlCommand _comand = new SqlCommand("UPDATE CustosDespesas SET Tipo = '@Tipo', Descricao = '@Descricao' WHERE IdCD like '@IdCD'", conn);
                _comand.Parameters.AddWithValue("@IdCD", cd.IdCD);
                _comand.Parameters.AddWithValue("@Tipo", cd.Tipo);
                _comand.Parameters.AddWithValue("@Descricao", cd.Descricao);
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
        /// <param name="cd"></param>
        /// <returns></returns>
        public bool ExcluirCustosDespesas(CustosDespesas cd)
        {

            SqlConnection conn = null;
            try
            {
                var stringConexao = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();

                conn = new SqlConnection(stringConexao);
                conn.Open();

                SqlCommand _comand = new SqlCommand("DELETE FROM CustosDespesas WHERE IdCD like '@IdCD'", conn);
                _comand.Parameters.AddWithValue("@IdCD", cd.IdCD);
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

        // GET: api/CustosDespesas/5
        [ResponseType(typeof(CustosDespesas))]
        public IHttpActionResult GetCustosDespesas(int id)
        {
            CustosDespesas custosDespesas = db.CustosDespesas.Find(id);
            if (custosDespesas == null)
            {
                return NotFound();
            }

            return Ok(custosDespesas);
        }

        // PUT: api/CustosDespesas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustosDespesas(int id, CustosDespesas custosDespesas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != custosDespesas.IdCD)
            {
                return BadRequest();
            }

            db.Entry(custosDespesas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustosDespesasExists(id))
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

        // POST: api/CustosDespesas
        [ResponseType(typeof(CustosDespesas))]
        public IHttpActionResult PostCustosDespesas(CustosDespesas custosDespesas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustosDespesas.Add(custosDespesas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = custosDespesas.IdCD }, custosDespesas);
        }

        // DELETE: api/CustosDespesas/5
        [ResponseType(typeof(CustosDespesas))]
        public IHttpActionResult DeleteCustosDespesas(int id)
        {
            CustosDespesas custosDespesas = db.CustosDespesas.Find(id);
            if (custosDespesas == null)
            {
                return NotFound();
            }

            db.CustosDespesas.Remove(custosDespesas);
            db.SaveChanges();

            return Ok(custosDespesas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustosDespesasExists(int id)
        {
            return db.CustosDespesas.Count(e => e.IdCD == id) > 0;
        }
    }
}