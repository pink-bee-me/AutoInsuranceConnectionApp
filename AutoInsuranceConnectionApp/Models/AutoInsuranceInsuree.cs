using System;

namespace AutoInsuranceConnectionApp.Models
{
    public class AutoInsuranceInsuree
    {
        public int InsureeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int SpeedingTickets { get; set; }
        public bool DUI { get; set; }
        public bool CoverageType { get; set; }



    }
}