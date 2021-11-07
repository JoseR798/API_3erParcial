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
using API_3erParcial.Models;

namespace API_3erParcial.Controllers
{
    public class BodegasController : ApiController
    {
        private DB_finalEntities db = new DB_finalEntities();

        // GET: api/Bodegas
        public IQueryable<Bodega> GetBodega()
        {
            return db.Bodega;
        }

        // GET: api/Bodegas/5
        [ResponseType(typeof(Bodega))]
        public IHttpActionResult GetBodega(int id)
        {
            Bodega bodega = db.Bodega.Find(id);
            if (bodega == null)
            {
                return NotFound();
            }

            return Ok(bodega);
        }

        // PUT: api/Bodegas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBodega(int id, Bodega bodega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bodega.BodegaID)
            {
                return BadRequest();
            }

            db.Entry(bodega).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodegaExists(id))
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

        // POST: api/Bodegas
        [ResponseType(typeof(Bodega))]
        public IHttpActionResult PostBodega(Bodega bodega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bodega.Add(bodega);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bodega.BodegaID }, bodega);
        }

        // DELETE: api/Bodegas/5
        [ResponseType(typeof(Bodega))]
        public IHttpActionResult DeleteBodega(int id)
        {
            Bodega bodega = db.Bodega.Find(id);
            if (bodega == null)
            {
                return NotFound();
            }

            db.Bodega.Remove(bodega);
            db.SaveChanges();

            return Ok(bodega);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BodegaExists(int id)
        {
            return db.Bodega.Count(e => e.BodegaID == id) > 0;
        }
    }
}