using AutoInsuranceConnectionApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;


namespace AutoInsuranceConnectionApp.Controllers
{

    private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LaurieSue\source\repos\AutoInsuranceConnectionApp\AutoInsuranceConnectionApp\App_Data\Insurance.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"


    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            using (InsuranceEntitiesQuotes db = new InsuranceEntitiesQuotes())
            {
                var insurees = db.Insurees;
                var insureeVMs = new List<InsureeVM>();
                foreach (var insuree in insurees) //need to get FirstName, LastName, EmailAddress and quote for all records in database
                {
                    var insureeVM = new InsureeVM();
                    insureeVM.FirstName = insuree.FirstName;
                    insureeVM.LastName = insuree.LastName;
                    insureeVM.EmailAddress = insuree.EmailAddress;
                    insureeVM.Quote = insuree.Quote;
                }
                return View(insureeVMs);
            }
        }
    }
}