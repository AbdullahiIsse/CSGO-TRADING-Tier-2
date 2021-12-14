using System.ComponentModel.DataAnnotations;
using Graph.ArgumentValidator;

namespace SEP3_tier2.Models
{
    [Validatable]
    public class User
    {
        public long id { get; set; }

       
        public string username { get; set; }
        
        
        public string password { get; set; }
        
     
        public long securitylevel { get; set; }


       
    }
}