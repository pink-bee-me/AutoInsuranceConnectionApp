namespace AutoInsuranceConnectionApp.ViewModels
{
    public class AutoQuoteVM
    {
        public int QuoteID { get; set; }
        public decimal BaseRate { get; set; }
        public decimal AgeUnder18 { get; set; }
        public decimal Age19to25 { get; set; }
        public decimal Age26AndUp { get; set; }
        public decimal AutoYearBefore2000 { get; set; }
        public decimal AutoYearAfter2015 { get; set; }
        public decimal IsPorsche { get; set; }
        public decimal IsCarerra911 { get; set; }
        public decimal SpeedingTickets { get; set; }
        public decimal SubTotalBeforeDUICalc { get; set; }
        public decimal DUIRateUP25Percent { get; set; }
        public decimal SubTotalAfterDUICalc { get; set; }
        public decimal FullCovRateUP50Percent { get; set; }
        public decimal SubTotalAfterFullCovCalc { get; set; }
        public decimal QuoteMonthly { get; set; }
        public decimal QuoteYearly { get; set; }
    }
}