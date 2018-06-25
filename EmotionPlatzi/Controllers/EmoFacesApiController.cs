﻿using System;
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
    public class EmoFacesApiController : ApiController
    {
        private EmotionPlatziContext db = new EmotionPlatziContext();

        // GET: api/EmoFacesApi
        public IQueryable<EmoFace> GetEmoFaces()
        {
            return db.EmoFaces;
        }

        // GET: api/EmoFacesApi/5
        [ResponseType(typeof(EmoFace))]
        public IHttpActionResult GetEmoFace(int id)
        {
            EmoFace emoFace = db.EmoFaces.Find(id);
            if (emoFace == null)
            {
                return NotFound();
            }

            return Ok(emoFace);
        }

        // PUT: api/EmoFacesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmoFace(int id, EmoFace emoFace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emoFace.Id)
            {
                return BadRequest();
            }

            db.Entry(emoFace).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmoFaceExists(id))
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

        // POST: api/EmoFacesApi
        [ResponseType(typeof(EmoFace))]
        public IHttpActionResult PostEmoFace(EmoFace emoFace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmoFaces.Add(emoFace);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emoFace.Id }, emoFace);
        }

        // DELETE: api/EmoFacesApi/5
        [ResponseType(typeof(EmoFace))]
        public IHttpActionResult DeleteEmoFace(int id)
        {
            EmoFace emoFace = db.EmoFaces.Find(id);
            if (emoFace == null)
            {
                return NotFound();
            }

            db.EmoFaces.Remove(emoFace);
            db.SaveChanges();

            return Ok(emoFace);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmoFaceExists(int id)
        {
            return db.EmoFaces.Count(e => e.Id == id) > 0;
        }
    }
}