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
    
    public partial class Quote
    {
        public int QuoteId { get; set; }
        public int InsureeId { get; set; }
        public decimal BaseRate { get; set; }
        public decimal AgeUnder18 { get; set; }
        public decimal Age19to25 { get; set; }
        public decimal Age26AndUp { get; set; }
        public decimal AutoYearPrior2000 { get; set; }
        public decimal AutoYearAfter2015 { get; set; }
        public decimal IsPorsche { get; set; }
        public decimal IsCarerra911 { get; set; }
        public decimal SpeedingTicket { get; set; }
        public decimal SubTotalBeforeDUICalc { get; set; }
        public decimal DUIRateUP25Percent { get; set; }
        public decimal SubTotalAfterDUICalc { get; set; }
        public decimal FullCovRateUP50Percent { get; set; }
        public decimal SubTotalAfterFullCovCalc { get; set; }
        public decimal QuoteInsCostPerMonth { get; set; }
        public decimal QuoteInsCostPerYear { get; set; }
    
        public virtual Insuree Insuree { get; set; }
    }
}
