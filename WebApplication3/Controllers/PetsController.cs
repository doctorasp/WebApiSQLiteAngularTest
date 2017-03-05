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
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class PetsController : ApiController
    {
        private PetsContext db = new PetsContext();

        // GET: api/Pets
        public IQueryable<Pets> GetPets()
        {
            return db.Pets;
        }



        // GET: api/Pets/5
        [ResponseType(typeof(Pets))]
        public IHttpActionResult GetPets(long id)
        {
            Pets pets = db.Pets.Find(id);
            if (pets == null)
            {
                return NotFound();
            }

            return Ok(pets);
        }

        // PUT: api/Pets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPets(long id, Pets pets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pets.PetsId)
            {
                return BadRequest();
            }

            db.Entry(pets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetsExists(id))
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

        // POST: api/Pets
        [ResponseType(typeof(Pets))]
        public IHttpActionResult PostPets(Pets pets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int id = pets.UserId;
            Users user = db.Users.Find(id);
            if (user != null)
            {
                user.PetsCount += 1;
            }
            db.Entry(user).State = EntityState.Modified;
            db.Pets.Add(pets);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pets.PetsId }, pets);
        }

        // DELETE: api/Pets/5
        [ResponseType(typeof(Pets))]
        public IHttpActionResult DeletePets(long id)
        {
            Pets pets = db.Pets.Find(id);
            if (pets == null)
            {
                return NotFound();
            }
            int UserId = pets.UserId;
            Users user = db.Users.Find(UserId);
            user.PetsCount -= 1;
            db.Entry(user).State = EntityState.Modified;

            db.Pets.Remove(pets);
            db.SaveChanges();

            return Ok(pets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetsExists(long id)
        {
            return db.Pets.Count(e => e.PetsId == id) > 0;
        }
    }
}