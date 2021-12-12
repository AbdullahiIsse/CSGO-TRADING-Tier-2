namespace SEP3_tier2.Models
{
    public class APIError
    {
        public string username { get; set; }
        public int status { get; set; }
        public string error { get; set; }
        public string message { get; set; }
        public string path { get; set; }
    }
}