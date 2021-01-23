using AutoInsuranceConnectionApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;



namespace AutoInsuranceConnectionApp.Controllers
{
   

    public class HomeController : Controller
    {
        //Connection String For The App Database
        private const string connectSqlDb = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LaurieSue\source\repos\
                                            AutoInsuranceConnectionApp\AutoInsuranceConnectionApp\App_Data\AutoInsurance.mdf;Integrated
                                            Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        private readonly string connectionString = connectSqlDb;



        // Landing Page (AreYou paying Too Much For Insurance...) *** BUTTON: GET FREE QUOTE(sends to EnterInsuree.cshtml)
        public ActionResult Index()
        {
            return View();// Returns View  Home/Index (Home/Index.cshtml)
        }







        // [GET:EnterInsuree]

        // NEVER!!! pass raw data into sql databases **USE PARAMETERS** for added security protection to help prevent sql injection attacks 

        // Action TREsult Of The Button:Get Free Quote Off Of The Landing Page 
        [HttpPost] // This view is the form that takes user input of the new Insuree
        public ActionResult EnterInsuree(string firstName, string lastName, string emailAddress, string dateOfBirth,
                                         string carYear, string carMake, string carModel, int speedingTickets, bool dui,
                                         bool coverageType)
        {
            var DateOfBirth = DateTime.Parse(dateOfBirth);


            string queryString = @"INSERT INTO Insurees (FirstName, LastName, EmailAddress, DateOfBirth, 
                                                         CarYear, CarMake, CarModel, DUI, CoverageType)
                                VALUES (@firstName, lastName, emailAddress, dateOfBirth, carYear, carMake,
                                        carModel, speedingTickets, dui, coverageType)";

            // using ADO.NET
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar);
                command.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar);
                command.Parameters.Add("@EmailAddress", System.Data.SqlDbType.NVarChar);
                command.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.DateTime);
                command.Parameters.Add("@CarYear", System.Data.SqlDbType.NVarChar);
                command.Parameters.Add("@CarMake", System.Data.SqlDbType.NVarChar);
                command.Parameters.Add("@CarModel", System.Data.SqlDbType.NVarChar);
                command.Parameters.Add("@SpeedingTickets", System.Data.SqlDbType.Int);
                command.Parameters.Add("@DUI", System.Data.SqlDbType.Bit);
                command.Parameters.Add("@CoverageType", System.Data.SqlDbType.NVarChar);

                command.Parameters["@FirstName"].Value = firstName;
                command.Parameters["@LastName"].Value = lastName;
                command.Parameters["@EmailAddress"].Value = emailAddress;
                command.Parameters["@DateOfBirth"].Value = dateOfBirth;
                command.Parameters["@CarYear"].Value = carYear;
                command.Parameters["@CarMake"].Value = carMake;
                command.Parameters["@CarModel"].Value = carModel;
                command.Parameters["@SpeedingTickets"].Value = speedingTickets;
                command.Parameters["@DUI"].Value = dui;
                command.Parameters["@CoverageType"].Value = coverageType;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            return View("Success");
        }








        public ActionResult Admin()
        {
            using (Insuree db = new Insuree())
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
                    return View();
            }
        }
    }
}