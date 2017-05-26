using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E.School.Models;

namespace E.School.Controllers
{
    public class DetaiController : Controller
    {
        private SCHOOLMANAGEMENTEntities db = new SCHOOLMANAGEMENTEntities();

        // GET: Detai
        public ActionResult Index()
        {
            var dETAIs = db.DETAIs.Include(d => d.LOAIDT);
            return View(dETAIs.ToList());
        }

        // GET: Detai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAI dETAI = db.DETAIs.Find(id);
            if (dETAI == null)
            {
                return HttpNotFound();
            }
            return View(dETAI);
        }

        // GET: Detai/Create
        public ActionResult Create()
        {
            ViewBag.MALDT = new SelectList(db.LOAIDTs, "MALDT", "TENLDT");
            return View();
        }

        // POST: Detai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADT,TENDT,MOTADT,NGUOIDENGHIDT,TRANGTHAIDT,NGAYDTHIEULUC,MALDT")] DETAI dETAI)
        {
            if (ModelState.IsValid)
            {
                db.DETAIs.Add(dETAI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MALDT = new SelectList(db.LOAIDTs, "MALDT", "TENLDT", dETAI.MALDT);
            return View(dETAI);
        }

        // GET: Detai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAI dETAI = db.DETAIs.Find(id);
            if (dETAI == null)
            {
                return HttpNotFound();
            }
            ViewBag.MALDT = new SelectList(db.LOAIDTs, "MALDT", "TENLDT", dETAI.MALDT);
            return View(dETAI);
        }

        // POST: Detai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MADT,TENDT,MOTADT,NGUOIDENGHIDT,TRANGTHAIDT,NGAYDTHIEULUC,MALDT")] DETAI dETAI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETAI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MALDT = new SelectList(db.LOAIDTs, "MALDT", "TENLDT", dETAI.MALDT);
            return View(dETAI);
        }

        // GET: Detai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAI dETAI = db.DETAIs.Find(id);
            if (dETAI == null)
            {
                return HttpNotFound();
            }
            return View(dETAI);
        }

        // POST: Detai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETAI dETAI = db.DETAIs.Find(id);
            db.DETAIs.Remove(dETAI);
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
