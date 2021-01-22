using AutoInsuranceConnectionApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace AutoInsuranceConnectionApp.Controllers
{


    public class HomeController : Controller
    {
        private const string connectSqlDb = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LaurieSue\source\repos\
                                            AutoInsuranceConnectionApp\AutoInsuranceConnectionApp\App_Data\AutoInsurance.mdf;Integrated
                                            Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        private readonly string connectionString = connectSqlDb;



        public ActionResult Index()
        {
            return View();
        }



        // NEVER!!! pass raw data into sql databases **USE PARAMETERS** for added security protection to help prevent sql injection attacks 
        [HttpPost]
        public ActionResult NewInsuree(string firstName, string lastName, string emailAddress, string dateOfBirth,
                                         string carYear, string carMake, string carModel, int speedingTickets, bool dui,
                                         bool coverageType)
        {
            var DateOfBirth = DateTime.Parse(dateOfBirth);


            string queryString = @"INSERT INTO Insurees (FirstName, LastName, EmailAddress, DateOfBirth, 
                                                         CarYear, CarMake, CarModel, DUI, CoverageType)
                                VALUES (@FirstName, LastName, EmailAddress, DateOfBirth, CarYear, CarMake,
                                        CarModel, SpeedingTickets, DUI, CoverageType)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar);




                command.Parameters

            }

            return View();
        }








        public ActionResult Admin()
        {
            using (AutoInsuranceEntities db = new AutoInsuranceEntities())
            {
                var insurees = db.Insurees;
                var insureeVMs = new List<InsureeVM>();
                foreach (var insuree in insurees) //need to get FirstName, LastName, EmailAddress, for all QuoteMonthly, and QuoteYearly records in database
                {
                    var insureeVM = new InsureeVM();
                    insureeVM.FirstName = insuree.FirstName;
                    insureeVM.LastName = insuree.LastName;
                    insureeVM.EmailAddress = insuree.EmailAddress;
                }
                var autoQuotes = db.AutoQuotes;
                var autoQuoteVMs = new List<AutoQuotesVM>();
                foreach ( )
                    return View(insureeVMs);
            }
        }
    }
}