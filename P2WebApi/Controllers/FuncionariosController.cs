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

namespace P2WebApi.Controllers
{
    public class FuncionariosController : ApiController
    {
        private ConexaoPadrao db = new ConexaoPadrao();

        // GET: api/Funcionarios
        public IQueryable<Funcionarios> GetFuncionarios()
        {
            return db.Funcionarios;
        }

        // GET: api/Funcionarios/5
        [ResponseType(typeof(Funcionarios))]
        public IHttpActionResult GetFuncionarios(int id)
        {
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return Ok(funcionarios);
        }

        /// <summary>
        /// Metodo de validar a senha
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="senha">String</param>
        /// <returns>Funcionarios</returns>
        public Funcionarios ValidaSenha(int id, string senha)
        {
            Funcionarios funcionario = db.Funcionarios.Find(id);
            if(funcionario == null)
            {
                return null;
            }
            else
            {
                if(senha == funcionario.Senha.ToString())
                {
                    return funcionario;
                }
                else
                {
                    return null;
                }
                
            }
        }

        // PUT: api/Funcionarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFuncionarios(int id, Funcionarios funcionarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcionarios.IdFuncionario)
            {
                return BadRequest();
            }

            db.Entry(funcionarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionariosExists(id))
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

        // POST: api/Funcionarios
        [ResponseType(typeof(Funcionarios))]
        public IHttpActionResult PostFuncionarios(Funcionarios funcionarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Funcionarios.Add(funcionarios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = funcionarios.IdFuncionario }, funcionarios);
        }

        // DELETE: api/Funcionarios/5
        [ResponseType(typeof(Funcionarios))]
        public IHttpActionResult DeleteFuncionarios(int id)
        {
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            db.Funcionarios.Remove(funcionarios);
            db.SaveChanges();

            return Ok(funcionarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FuncionariosExists(int id)
        {
            return db.Funcionarios.Count(e => e.IdFuncionario == id) > 0;
        }
    }
}