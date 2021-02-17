using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFreakSide.Models;

namespace TheFreakSide.Controllers
{
    public class OrdersController : Controller
    {
        private TheFreakSideContext context = new TheFreakSideContext();

        [HttpGet]
        public ActionResult Index(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var product = context.Products.Where(x => x.Id == id).FirstOrDefault();

            ViewData["Product"] = product;

            HttpContext.Session.SetString("product_id", product.Id.ToString());


            ViewBag.IVA = Math.Round(product.Price * 1.21, 2);

            return View();
        }

        public ActionResult SuccessOrder(Order neworder)
        {
            ViewData["Order"] = neworder;
            ViewBag.IDOrder = GetLastIDOrder();
            var product = context.Products.Where(x => x.Id == neworder.ProductID).FirstOrDefault();
            ViewData["Product"] = product;
            return View("SuccessOrder");
        }

        [HttpPost]
        public ActionResult Index(Order order)
        {
            var newOrder = InsertOrder(order);
            return SuccessOrder(newOrder);
        }

        public String GetLastIDOrder()
        {
            var lastOrder = context.Orders.OrderBy(x => x.Id).Last().Id.ToString();
            return lastOrder;
        }

        public Order InsertOrder(Order order)
        {
            var newOrder = new Order();

            newOrder.ProductID = Int16.Parse(HttpContext.Session.GetString("product_id"));
            var product = context.Products.Where(x => x.Id == newOrder.ProductID).FirstOrDefault();

            newOrder.TotalPrice = Math.Round(product.Price * 1.21, 2);
            newOrder.FirstName = order.FirstName;
            newOrder.LastName = order.LastName;
            newOrder.Email = order.Email;
            newOrder.Address = order.Address;
            newOrder.City = order.City;
            newOrder.Postcode = order.Postcode;
            newOrder.PhoneNumber = order.PhoneNumber;

            context.Add(newOrder);

            product.StockQuantity -= 1;
            product.SoldQuantity += 1;

            context.Update(product);

            context.SaveChanges();

            return newOrder;
        }
    }
}
