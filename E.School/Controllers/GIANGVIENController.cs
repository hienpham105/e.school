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
    public class GiangvienController : Controller
    {
        private SCHOOLMANAGEMENTEntities db = new SCHOOLMANAGEMENTEntities();

        // GET: GIANGVIEN
        public ActionResult Index()
        {
            var gIANGVIENs = db.GIANGVIENs.Include(g => g.CHUCVU).Include(g => g.CHUYENNGANH).Include(g => g.DONVI).Include(g => g.HOCVI);
            return View(gIANGVIENs.ToList());
        }

        // GET: GIANGVIEN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIANGVIEN gIANGVIEN = db.GIANGVIENs.Find(id);
            if (gIANGVIEN == null)
            {
                return HttpNotFound();
            }
            return View(gIANGVIEN);
        }

        // GET: GIANGVIEN/Create
        public ActionResult Create()
        {
            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV");
            ViewBag.MACN = new SelectList(db.CHUYENNGANHs, "MACN", "TENCN");
            ViewBag.MADV = new SelectList(db.DONVIs, "MADV", "TENDV");
            ViewBag.MAHV = new SelectList(db.HOCVIs, "MAHV", "TENHV");
            return View();
        }

        // POST: GIANGVIEN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAGV,HOGV,TENGV,QUEQUAN,ANHDAIDIEN,NGAYSINH,CMND,EMAIL,SDT,DIACHI,GIOITINH,MOTA,TRANGTHAIGV,MADV,MACV,MAHV,MACN")] GIANGVIEN gIANGVIEN)
        {
            if (ModelState.IsValid)
            {
                db.GIANGVIENs.Add(gIANGVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV", gIANGVIEN.MACV);
            ViewBag.MACN = new SelectList(db.CHUYENNGANHs, "MACN", "TENCN", gIANGVIEN.MACN);
            ViewBag.MADV = new SelectList(db.DONVIs, "MADV", "TENDV", gIANGVIEN.MADV);
            ViewBag.MAHV = new SelectList(db.HOCVIs, "MAHV", "TENHV", gIANGVIEN.MAHV);
            return View(gIANGVIEN);
        }

        // GET: GIANGVIEN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIANGVIEN gIANGVIEN = db.GIANGVIENs.Find(id);
            if (gIANGVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV", gIANGVIEN.MACV);
            ViewBag.MACN = new SelectList(db.CHUYENNGANHs, "MACN", "TENCN", gIANGVIEN.MACN);
            ViewBag.MADV = new SelectList(db.DONVIs, "MADV", "TENDV", gIANGVIEN.MADV);
            ViewBag.MAHV = new SelectList(db.HOCVIs, "MAHV", "TENHV", gIANGVIEN.MAHV);
            return View(gIANGVIEN);
        }

        // POST: GIANGVIEN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAGV,HOGV,TENGV,QUEQUAN,ANHDAIDIEN,NGAYSINH,CMND,EMAIL,SDT,DIACHI,GIOITINH,MOTA,TRANGTHAIGV,MADV,MACV,MAHV,MACN")] GIANGVIEN gIANGVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIANGVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV", gIANGVIEN.MACV);
            ViewBag.MACN = new SelectList(db.CHUYENNGANHs, "MACN", "TENCN", gIANGVIEN.MACN);
            ViewBag.MADV = new SelectList(db.DONVIs, "MADV", "TENDV", gIANGVIEN.MADV);
            ViewBag.MAHV = new SelectList(db.HOCVIs, "MAHV", "TENHV", gIANGVIEN.MAHV);
            return View(gIANGVIEN);
        }

        // GET: GIANGVIEN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIANGVIEN gIANGVIEN = db.GIANGVIENs.Find(id);
            if (gIANGVIEN == null)
            {
                return HttpNotFound();
            }
            return View(gIANGVIEN);
        }

        // POST: GIANGVIEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GIANGVIEN gIANGVIEN = db.GIANGVIENs.Find(id);
            db.GIANGVIENs.Remove(gIANGVIEN);
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
