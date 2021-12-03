namespace SEP3_tier2.Models
{
    public class Payment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string cardnumber { get; set; }
        public string expirationdate { get; set; }
        public string securitycode { get; set; }

        public string wallet { get; set; }
    }
}