using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFreakSide.Models;

namespace TheFreakSide.Controllers
{
    public class ProductsController : Controller
    {
        private TheFreakSideContext context = new TheFreakSideContext();

        [HttpGet]
        public ActionResult Index(int categoryID, int pageNumber, string type, int pageSize = 6)
        {
            ViewData["Categories"] = context.Categories.ToList();

            var products = context.Products.ToList();
            if (categoryID != 0)
            {
                products = products.Where(x => x.CategoryID == categoryID).ToList();
                ViewBag.TotalPages = 0;
                return View(products);
            }

            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }

            var totalPages = ((double)products.Count() / (double)pageSize);

            if ((totalPages % 1) != 0)
            {
                totalPages = Convert.ToInt32(totalPages) + 1;
            }

            if (type == "next" && pageNumber < totalPages)
            {
                ++pageNumber;
            }

            if (type == "previous" && pageNumber > 1)
            {
                --pageNumber;
            }

            ViewBag.PageNumber = pageNumber;

            ViewBag.TotalPages = totalPages;

            var productsPaginated = products.Skip(ExcludeRecords).Take(pageSize);

            return View(productsPaginated);
        }

        [HttpGet]
        public ActionResult Product(int id)
        {
            var product = context.Products.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.CategoryName = context.Categories.Where(x => x.Id == product.CategoryID).FirstOrDefault().Name;
            return View(product);
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            List<Product> productsFiltered = context.Products.Where(x => x.Name.Contains(name)).ToList();
            ViewData["Categories"] = context.Categories.ToList();

            return View("Index", productsFiltered);
        }
    }
}
