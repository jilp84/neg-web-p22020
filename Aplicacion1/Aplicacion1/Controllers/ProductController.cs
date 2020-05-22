using Aplicacion1.Context;
using Aplicacion1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}