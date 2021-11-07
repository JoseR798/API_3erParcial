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
    public class ReportesController : ApiController
    {
        private DB_finalEntities db = new DB_finalEntities();

        // GET: api/Reportes
        public IQueryable<Reporte> GetReporte()
        {
            return db.Reporte;
        }

        // GET: api/Reportes/5
        [ResponseType(typeof(Reporte))]
        public IHttpActionResult GetReporte(int id)
        {
            Reporte reporte = db.Reporte.Find(id);
            if (reporte == null)
            {
                return NotFound();
            }

            return Ok(reporte);
        }

        // PUT: api/Reportes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReporte(int id, Reporte reporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reporte.ReporteID)
            {
                return BadRequest();
            }

            db.Entry(reporte).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReporteExists(id))
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

        // POST: api/Reportes
        [ResponseType(typeof(Reporte))]
        public IHttpActionResult PostReporte(Reporte reporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reporte.Add(reporte);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reporte.ReporteID }, reporte);
        }

        // DELETE: api/Reportes/5
        [ResponseType(typeof(Reporte))]
        public IHttpActionResult DeleteReporte(int id)
        {
            Reporte reporte = db.Reporte.Find(id);
            if (reporte == null)
            {
                return NotFound();
            }

            db.Reporte.Remove(reporte);
            db.SaveChanges();

            return Ok(reporte);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReporteExists(int id)
        {
            return db.Reporte.Count(e => e.ReporteID == id) > 0;
        }
    }
}