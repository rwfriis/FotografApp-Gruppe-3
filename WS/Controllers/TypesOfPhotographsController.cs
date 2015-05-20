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
using WS;

namespace WS.Controllers
{
    public class TypesOfPhotographsController : ApiController
    {
        private FotografAppContext db = new FotografAppContext();

        // GET: api/TypesOfPhotographs
        public IQueryable<TypesOfPhotograph> GetTypesOfPhotographs()
        {
            return db.TypesOfPhotographs;
        }

        // GET: api/TypesOfPhotographs/5
        [ResponseType(typeof(TypesOfPhotograph))]
        public IHttpActionResult GetTypesOfPhotograph(string id)
        {
            TypesOfPhotograph typesOfPhotograph = db.TypesOfPhotographs.Find(id);
            if (typesOfPhotograph == null)
            {
                return NotFound();
            }

            return Ok(typesOfPhotograph);
        }

        // PUT: api/TypesOfPhotographs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypesOfPhotograph(string id, TypesOfPhotograph typesOfPhotograph)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typesOfPhotograph.Name)
            {
                return BadRequest();
            }

            db.Entry(typesOfPhotograph).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypesOfPhotographExists(id))
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

        // POST: api/TypesOfPhotographs
        [ResponseType(typeof(TypesOfPhotograph))]
        public IHttpActionResult PostTypesOfPhotograph(TypesOfPhotograph typesOfPhotograph)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypesOfPhotographs.Add(typesOfPhotograph);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TypesOfPhotographExists(typesOfPhotograph.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = typesOfPhotograph.Name }, typesOfPhotograph);
        }

        // DELETE: api/TypesOfPhotographs/5
        [ResponseType(typeof(TypesOfPhotograph))]
        public IHttpActionResult DeleteTypesOfPhotograph(string id)
        {
            TypesOfPhotograph typesOfPhotograph = db.TypesOfPhotographs.Find(id);
            if (typesOfPhotograph == null)
            {
                return NotFound();
            }

            db.TypesOfPhotographs.Remove(typesOfPhotograph);
            db.SaveChanges();

            return Ok(typesOfPhotograph);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypesOfPhotographExists(string id)
        {
            return db.TypesOfPhotographs.Count(e => e.Name == id) > 0;
        }
    }
}