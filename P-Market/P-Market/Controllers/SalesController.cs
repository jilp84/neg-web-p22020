using P_Market.Data;
using P_Market.Models;
using P_Market.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

                    foreach (var item in salesViewModel.SaleDetails)
                    {
                        var product = db.Products.Find(item.ProductId);
                        SaleDetails saleDetails = new SaleDetails {
                            ProductId = item.ProductId,
                            SaleDetailsQuantity = item.ProductQuantity,
                            SaleDetailsSubTotal = product.ProductPrice * item.ProductQuantity,
                            SaleKey = sale.SaleKey
                        };

                        db.SaleDetails.Add(saleDetails);
                        db.SaveChanges();

                    }

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