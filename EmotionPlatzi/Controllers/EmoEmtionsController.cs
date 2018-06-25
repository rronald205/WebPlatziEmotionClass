using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmotionPlatzi.Models;

namespace EmotionPlatzi.Controllers
{
    public class EmoEmtionsController : Controller
    {
        private EmotionPlatziContext db = new EmotionPlatziContext();

        // GET: EmoEmtions
        public ActionResult Index()
        {
            var emoEmotions = db.EmoEmotions.Include(e => e.Faces);
            return View(emoEmotions.ToList());
        }

        // GET: EmoEmtions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmoEmtion emoEmtion = db.EmoEmotions.Find(id);
            if (emoEmtion == null)
            {
                return HttpNotFound();
            }
            return View(emoEmtion);
        }

        // GET: EmoEmtions/Create
        public ActionResult Create()
        {
            ViewBag.EmoFaceId = new SelectList(db.EmoFaces, "Id", "Id");
            return View();
        }

        // POST: EmoEmtions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Score,EmoFaceId,EmotionType")] EmoEmtion emoEmtion)
        {
            if (ModelState.IsValid)
            {
                db.EmoEmotions.Add(emoEmtion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmoFaceId = new SelectList(db.EmoFaces, "Id", "Id", emoEmtion.EmoFaceId);
            return View(emoEmtion);
        }

        // GET: EmoEmtions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmoEmtion emoEmtion = db.EmoEmotions.Find(id);
            if (emoEmtion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmoFaceId = new SelectList(db.EmoFaces, "Id", "Id", emoEmtion.EmoFaceId);
            return View(emoEmtion);
        }

        // POST: EmoEmtions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Score,EmoFaceId,EmotionType")] EmoEmtion emoEmtion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emoEmtion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmoFaceId = new SelectList(db.EmoFaces, "Id", "Id", emoEmtion.EmoFaceId);
            return View(emoEmtion);
        }

        // GET: EmoEmtions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmoEmtion emoEmtion = db.EmoEmotions.Find(id);
            if (emoEmtion == null)
            {
                return HttpNotFound();
            }
            return View(emoEmtion);
        }

        // POST: EmoEmtions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmoEmtion emoEmtion = db.EmoEmotions.Find(id);
            db.EmoEmotions.Remove(emoEmtion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
