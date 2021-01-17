using AutoInsuranceConnectionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoInsuranceConnectionApp.Controllers
{
    public class QuoteController : Controller
    {
        private InsuranceEntitiesQuotes db = new InsuranceEntitiesQuotes();  

        // GET: Quote
        public ActionResult GetInsureeData(int id)
        {
            var data = db.Insurees
            return View(data);
        }


      public ActionResult QuoteCalculator(Insuree Insuree)
        {
            var quote = new Quote();


       }

    }
}