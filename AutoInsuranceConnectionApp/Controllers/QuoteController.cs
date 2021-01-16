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
        // GET: Quote
        public ActionResult GetInsureeData()
        {
            Insuree quoteData = new Insuree();
            return View(quoteData);
        }


      //  public ActionResult CalculateQuote()
      //  {

      //  }

    }
}