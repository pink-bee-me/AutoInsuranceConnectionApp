using AutoInsuranceConnectionApp.Models;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AutoInsuranceConnectionApp.Controllers
{
    public class InsureeController : Controller
    {
        //Connection String For The App Database
        private const string connectSqlDb = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LaurieSue\source\repos\
                                            AutoInsuranceConnectionApp\AutoInsuranceConnectionApp\App_Data\AutoInsurance.mdf;Integrated
                                            Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        private readonly string connectionString = connectSqlDb;
    
    private Insuree db = new Insuree();

    // GET: Insuree
    public ActionResult Index()
    {
        return View(db.Insurees.ToList());
    }

    // GET: Insuree/Details/5
    public ActionResult Details(int? InsureeID)
    {
        if (InsureeID == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Insuree insuree = db.Insurees.Find(InsureeID);
        if (insuree == null)
        {
            return HttpNotFound();
        }
        return View(insuree);
    }

    // GET: Insuree/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Insuree/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "InsureeID,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,QuoteMonthly,QuoteYearly, QuoteID")] Insuree insuree)
    {
        using (Insuree Insuree = new Insuree())

            if (ModelState.IsValid)
            {
                db.Insurees.Add(insuree);
                db.SaveChanges();
            }
        return View();

    }


    public ActionResult CalculateQuote(Insuree Insure)

    {
            using (Insuree db)
            {
                 Insuree Insurees = new Insuree();
                Insuree AutoQuotes = new AutoInsuranceEntites.AutoQuote.();                
            var age = DateTime.Now.Year - Insuree.DateOfBirth.Year;

        if (Insuree.DateOfBirth.Month > DateTime.Now.Month
        || Insuree.DateOfBirth.Month == DateTime.Now.Month
        && Insuree.DateOfBirth.Day > DateTime.Now.Day)
            age--;

        {
            under18 = (age < 18) ? 100.00 : 0.00;
            btw19and25 = ((age > 18) && (age <= 25)) ? 50.00 : 0.00;
            over25 = (age > 25) ? 25.00 : 0.00;
        }

        yesIsPorsche = (Insuree.CarMake == "Porsche") ? 25.00 : 0.00;
        yesIsCarrera = (Insuree.CarModel == "Carrera") ? 25.00 : 0.00;

        speedingTickets = Insuree.SpeedingTickets;
        speedingTicketsRate = speedingTickets * 10.00;


        baseRate = 50.00;

        subtotalBeforeDUI = baseRate + ageUnder18 + btw19To25 + age26AndUp +
                            autoYearPrior2000 + autoYearAfter2015 + yesIsPorsche +
                            yesIsCarrera + speedingTicketsRate;


        isTrueDUI = (Insuree.DUI == true) ? 1 : 0;
        duiRate = subtotalBeforeDUI * 0.25;//Calculating the rate of increase if DUI is true
        yesDUI = (isTrueDUI == 1) ? duiRate : 0.00;// value that will be placed in Quote DUIRateUP25Percent
        subtotalAfterDUI = yesDUI + subtotalBeforeDUI;// value that will be placed in Quote SubTotalAfterDUICalc



        coverageTypeFull = (Insuree.CoverageType == true) ? 1 : 0;
        fullCoverageRate = subtotalAfterDUI * 0.50;// calculating the rate of increase if FullCoverage is true
        yesFullCoverage = (coverageTypeFull == 1) ? fullCoverageRate : 0.00;//value that will be placed in FullCovRateUP50Percent  
        subtotalAfterCoverageType = subtotalAfterDUI + yesFullCoverage;



        monthlyQuote = subtotalAfterCoverageType;
        yearlyQuote = subtotalAfterCoverageType * 12;



        string queryString = @"INSERT INTO AutoQuotes (FirstName, LastName, EmailAddress, DateOfBirth, 
                                                               CarYear, CarMake, CarModel, SpeedingTickets, DUI,
                                                               CoverageType)
                                                       VALUES (@FirstName, LastName, EmailAddress, DateOfBirth,
                                                               CarYear, CarMake, CarModel, SpeedingTickets, DUI,
                                                               CoverageType)";


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar);
        }



        return ViewPage(Insuree Insuree, AutoQuote AutoQuote);
    }



    // GET: Insuree/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Insuree insuree = db.Insurees.Find(id);
        if (insuree == null)
        {
            return HttpNotFound();
        }
        return View(insuree);
    }

    // POST: Insuree/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
    {
        if (ModelState.IsValid)
        {
            db.Entry(insuree).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(insuree);
    }

    // GET: Insuree/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Insuree insuree = db.Insurees.Find(id);
        if (insuree == null)
        {
            return HttpNotFound();
        }
        return View(insuree);
    }

    // POST: Insuree/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Insuree insuree = db.Insurees.Find(id);
        db.Insurees.Remove(insuree);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }

    public ActionResult Admin()
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Insuree insuree = db.Insurees.Find(id);
        if (insuree == null)
        {
            return HttpNotFound();
        }
        return View("Admin", "Admin");
    }
}
}
