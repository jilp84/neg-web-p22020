using P_Market.Data;
using P_Market.Models;
using P_Market.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P_Market.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }
        // GET: Sales\Create
        public ActionResult Create()
        {

            return View();
        }
        // Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleViewModel salesViewModel)
        {
            try
            {
                using (P_MarketContext db = new P_MarketContext()) {
                    
                    Sale sale = new Sale {
                        ClientKey = salesViewModel.ClientKey,
                        SaleDate = DateTime.Now
                    };

                    db.Sales.Add(sale);
                    db.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View(salesViewModel);
            }

            //return View();
        }

    }
}