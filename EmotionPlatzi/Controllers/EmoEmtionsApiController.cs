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
using EmotionPlatzi.Models;

namespace EmotionPlatzi.Controllers
{
    public class EmoEmtionsApiController : ApiController
    {
        private EmotionPlatziContext db = new EmotionPlatziContext();

        // GET: api/EmoEmtionsApi
        public IQueryable<EmoEmtion> GetEmoEmotions()
        {
            return db.EmoEmotions;
        }

        // GET: api/EmoEmtionsApi/5
        [ResponseType(typeof(EmoEmtion))]
        public IHttpActionResult GetEmoEmtion(int id)
        {
            EmoEmtion emoEmtion = db.EmoEmotions.Find(id);
            if (emoEmtion == null)
            {
                return NotFound();
            }

            return Ok(emoEmtion);
        }

        // PUT: api/EmoEmtionsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmoEmtion(int id, EmoEmtion emoEmtion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emoEmtion.Id)
            {
                return BadRequest();
            }

            db.Entry(emoEmtion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmoEmtionExists(id))
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

        // POST: api/EmoEmtionsApi
        [ResponseType(typeof(EmoEmtion))]
        public IHttpActionResult PostEmoEmtion(EmoEmtion emoEmtion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmoEmotions.Add(emoEmtion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emoEmtion.Id }, emoEmtion);
        }

        // DELETE: api/EmoEmtionsApi/5
        [ResponseType(typeof(EmoEmtion))]
        public IHttpActionResult DeleteEmoEmtion(int id)
        {
            EmoEmtion emoEmtion = db.EmoEmotions.Find(id);
            if (emoEmtion == null)
            {
                return NotFound();
            }

            db.EmoEmotions.Remove(emoEmtion);
            db.SaveChanges();

            return Ok(emoEmtion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmoEmtionExists(int id)
        {
            return db.EmoEmotions.Count(e => e.Id == id) > 0;
        }
    }
}