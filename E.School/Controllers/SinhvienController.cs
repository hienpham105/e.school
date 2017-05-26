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
    public class SinhvienController : Controller
    {
        private SCHOOLMANAGEMENTEntities db = new SCHOOLMANAGEMENTEntities();

        // GET: Sinhvien
        public ActionResult Index()
        {
            var sINHVIENs = db.SINHVIENs.Include(s => s.CHUYENNGANH);
            return View(sINHVIENs.ToList());
        }

        // GET: Sinhvien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        // GET: Sinhvien/Create
        public ActionResult Create()
        {
            ViewBag.MACN = new SelectList(db.CHUYENNGANHs, "MACN", "TENCN");
            return View();
        }

        // POST: Sinhvien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MSSV,HOSV,TENSV,ANHDAIDIEN,QUEQUAN,NGAYSINHSV,CMNDSV,DIEM_TBTL,SDTSV,SDT_PHUHUYNH,EMAIL,DIACHI_SV,DIACHI_THUONGTRU,GIOITINH,TRANGTHAISV,MACN")] SINHVIEN sINHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.SINHVIENs.Add(sINHVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MACN = new SelectList(db.CHUYENNGANHs, "MACN", "TENCN", sINHVIEN.MACN);
            return View(sINHVIEN);
        }

        // GET: Sinhvien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MACN = new SelectList(db.CHUYENNGANHs, "MACN", "TENCN", sINHVIEN.MACN);
            return View(sINHVIEN);
        }

        // POST: Sinhvien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MSSV,HOSV,TENSV,ANHDAIDIEN,QUEQUAN,NGAYSINHSV,CMNDSV,DIEM_TBTL,SDTSV,SDT_PHUHUYNH,EMAIL,DIACHI_SV,DIACHI_THUONGTRU,GIOITINH,TRANGTHAISV,MACN")] SINHVIEN sINHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sINHVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MACN = new SelectList(db.CHUYENNGANHs, "MACN", "TENCN", sINHVIEN.MACN);
            return View(sINHVIEN);
        }

        // GET: Sinhvien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        // POST: Sinhvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            db.SINHVIENs.Remove(sINHVIEN);
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
