//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoInsuranceConnectionApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Insuree
    {
        public int InsureeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int SpeedingTickets { get; set; }
        public bool CoverageType { get; set; }
        public decimal QuoteMonthly { get; set; }
        public decimal QuoteYearly { get; set; }
        public int QuoteID { get; set; }
    
        public virtual AutoQuote AutoQuote { get; set; }
    }
}
