using Aplicacion1.Context;
using Aplicacion1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Aplicacion1.Controllers
{
    public class ProductController : Controller
    {

        private StoreContext db = new StoreContext();

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.ToList();

            return View(products);
        }

        //GET: Product/Details/5
        public ActionResult Details(int? id) {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var producto = db.Products.Find(id);

            if (producto == null)
            {
                return HttpNotFound();
            }

            return View(producto);

        }

        // GET: Product/Create
        public ActionResult Create() {

            return View();

        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product) {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception)
            {
                return View(product);
            }

        }

        //GET: Product/Edit/5
        public ActionResult Edit(int? id) {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var producto = db.Products.Find(id);

            if (producto == null)
            {
                return HttpNotFound();
            }

            return View(producto);

        }

        //POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product) {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception)
            {

                return View(product);
            }

        }

    }
}