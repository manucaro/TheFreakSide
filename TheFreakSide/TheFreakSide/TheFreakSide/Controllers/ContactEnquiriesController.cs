using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFreakSide.Models;

namespace TheFreakSide.Controllers
{
    public class ContactEnquiriesController : Controller
    {
        private TheFreakSideContext context = new TheFreakSideContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SuccessContactEnquirie()
        {
            return View("SuccessContactEnquirie");
        }

        [HttpPost]
        public ActionResult Index(ContactEnquirie contactEnquirie)
        {
            InsertContactEnquirie(contactEnquirie);
            return SuccessContactEnquirie();
        }

        // POST: ContactController/Create
        public void InsertContactEnquirie(ContactEnquirie contactEnquirie)
        {
            context.Add(contactEnquirie);
            context.SaveChanges();
        }
    }
}
