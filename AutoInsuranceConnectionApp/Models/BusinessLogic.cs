using System;

namespace AutoInsuranceConnectionApp.Models
{
    public class BusinessLogic

    {
        public void BusinessLogic(Insuree Insuree)

        {
            AutoQuote autoQuote = new AutoQuote();







         
            public void CalculateAge(Insuree DateOfBirth)
        {

            var years = DateTime.Now.Year - Insuree.DateOfBirth.Year;
            var age = years;

            if (Insuree.DateOfBirth.Month > DateTime.Now.Month || Insuree.DateOfBirth.Month == DateTime.Now.Month && Insuree.DateOfBirth.Day > DateTime.Now.Day)
                years--;
                {
                    var under18 = (age < 18) ? 100.00 : 0.00;
                    var btw19and25 = ((age > 18) && (age <= 25)) ? 50.00 : 0.00;
                    var over25 = (age > 25) ? 25.00 : 0.00;

                    autoQuote.AgeUnder18 = (decimal)under18;
                    autoQuote.Age19to25 = (decimal)btw19and25;
                    autoQuote.Age26AndUp = (decimal)over25;





                }
        }


        public void CalculateAutoYear(Insuree Insuree)
        {
            var autoYearBefore2000 = (Insuree.CarYear < 2000) ? 25.00 : 0.00;
            var autoYearAfter2015 = (Insuree.CarYear > 2015) ? 25.00 : 0.00;

            AutoQuote.AutoYearBefore2000 =

        }


        public void CalculateAutoMakeAndModel(Insuree Insuree)
        {
            var yesIsPorsche = (Insuree.CarMake == "Porsche") ? 25.00 : 0.00;
            var yesIsCarrera = (Insuree.CarModel == "Carrera") ? 25.00 : 0.00;

        }

        public void CalculateSpeedingTickets(Insuree Insuree)
        {
            var speedingTickets = Insuree.SpeedingTickets;
            var speedingTicketsRate = speedingTickets * 10.00;

        }

        public void SubTotalWithoutDUI(Insuree Insuree, double ageUnder18, double btw19To25,
                                       double age26AndUp, double autoYearPrior2000, double autoYearAfter2015,
                                       double yesIsPorsche, double yesIsCarrera, double speedingTicketsRate)
        {
            var baseRate = 50.00;

            var subtotalBeforeDUI = baseRate + ageUnder18 + btw19To25 + age26AndUp +
                                    autoYearPrior2000 + autoYearAfter2015 + yesIsPorsche +
                                    yesIsCarrera + speedingTicketsRate;

        }


        public void CalculateDUI(Insuree Insuree, double subtotalBeforeDUI)
        {
            var isTrueDUI = (Insuree.DUI == true) ? 1 : 0;
            var duiRate = subtotalBeforeDUI * 0.25;//Calculating the rate of increase if DUI is true
            var yesDUI = (isTrueDUI == 1) ? duiRate : 0.00;// value that will be placed in Quote DUIRateUP25Percent
            var subtotalAfterDUI = yesDUI + subtotalBeforeDUI;// value that will be placed in Quote SubTotalAfterDUICalc


        }


        public void CalculateCoverageType(double subtotalAfterDUI, Insuree CoverageType)
        {
            var coverageTypeFull = (Insuree.CoverageType == true) ? 1 : 0;
            var fullCoverageRate = subtotalAfterDUI * 0.50;// calculating the rate of increase if FullCoverage is true
            var yesFullCoverage = (coverageTypeFull == 1) ? fullCoverageRate : 0.00;//value that will be placed in FullCovRateUP50Percent  
            var subtotalAfterCoverageType = subtotalAfterDUI + yesFullCoverage;
        }

        public void CalculateQuote(double subtotalAfterCoverageType)
        {
            var monthlyQuote = subtotalAfterCoverageType;
            var yearlyQuote = subtotalAfterCoverageType * 12;

        }

                string queryString = @"INSERT INTO AutoQuotes (FirstName, LastName, EmailAddress, DateOfBirth, 
                                                         CarYear, CarMake, CarModel, DUI, CoverageType)
                                VALUES (@FirstName, LastName, EmailAddress, DateOfBirth, CarYear, CarMake,
                                        CarModel, SpeedingTickets, DUI, CoverageType)";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar);
                }


    }
}