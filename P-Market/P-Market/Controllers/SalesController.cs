using P_Market.Data;
using P_Market.Models;
using P_Market.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            try
            {
                using (P_MarketContext db = new P_MarketContext())
                {

                    var sales = db.Sales.Include(i => i.Client).Include(i => i.SaleDetails).ToList();

                    return View(ToSalesViewModel(sales));

                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorIndex = "Error: " + ex.Message;
                return View();
            }


        }

        private object ToSalesViewModel(List<Sale> sales)
        {
            List<SaleViewModel> salesViewModel = new List<SaleViewModel>();

            foreach (var item in sales)
            {
                SaleViewModel saleViewModel = new SaleViewModel
                {

                    SaleKey = item.SaleKey,
                    ClientKey = item.ClientKey,
                    ClientName = item.Client.ClientName,
                    SaleDate = item.SaleDate,
                    SaleDetails = new List<SaleDetailsViewModel>()

                };

                using (P_MarketContext db = new P_MarketContext())
                {
                    var saleDetails = db.SaleDetails.Where(i => i.SaleKey == item.SaleKey).Include(i => i.Product).ToList();

                    foreach (var product in saleDetails)
                    {
                        saleViewModel.SaleDetails.Add(new SaleDetailsViewModel
                        {
                            ProductId = product.ProductId,
                            ProductName = product.Product.ProductName,
                            ProductPrice = product.SaleDetailsSubTotal / product.SaleDetailsQuantity,
                            ProductQuantity = product.SaleDetailsQuantity
                        });
                    }
                }
                salesViewModel.Add(saleViewModel);
            }
            return salesViewModel;

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
                using (P_MarketContext db = new P_MarketContext())
                {

                    Sale sale = new Sale
                    {
                        ClientKey = salesViewModel.ClientKey,
                        SaleDate = DateTime.Now
                    };

                    db.Sales.Add(sale);
                    db.SaveChanges();

                    foreach (var item in salesViewModel.SaleDetails)
                    {
                        var product = db.Products.Find(item.ProductId);
                        SaleDetails saleDetails = new SaleDetails
                        {
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