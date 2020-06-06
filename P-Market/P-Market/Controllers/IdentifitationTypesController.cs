using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using P_Market.Data;
using P_Market.Models;

namespace P_Market.Controllers
{
    public class IdentifitationTypesController : Controller
    {
        private P_MarketContext db = new P_MarketContext();

        // GET: IdentifitationTypes
        public ActionResult Index()
        {
            return View(db.IdentifitationTypes.ToList());
        }

        // GET: IdentifitationTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentifitationType identifitationType = db.IdentifitationTypes.Find(id);
            if (identifitationType == null)
            {
                return HttpNotFound();
            }
            return View(identifitationType);
        }

        // GET: IdentifitationTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IdentifitationTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdentifitationTypeKey,IdentifitationTypeName")] IdentifitationType identifitationType)
        {
            if (ModelState.IsValid)
            {
                db.IdentifitationTypes.Add(identifitationType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(identifitationType);
        }

        // GET: IdentifitationTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentifitationType identifitationType = db.IdentifitationTypes.Find(id);
            if (identifitationType == null)
            {
                return HttpNotFound();
            }
            return View(identifitationType);
        }

        // POST: IdentifitationTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdentifitationTypeKey,IdentifitationTypeName")] IdentifitationType identifitationType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(identifitationType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(identifitationType);
        }

        // GET: IdentifitationTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentifitationType identifitationType = db.IdentifitationTypes.Find(id);
            if (identifitationType == null)
            {
                return HttpNotFound();
            }
            return View(identifitationType);
        }

        // POST: IdentifitationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdentifitationType identifitationType = db.IdentifitationTypes.Find(id);
            db.IdentifitationTypes.Remove(identifitationType);
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
