using Aplicacion1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}