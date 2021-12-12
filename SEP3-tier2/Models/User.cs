using System.ComponentModel.DataAnnotations;
using Graph.ArgumentValidator;

namespace SEP3_tier2.Models
{
    [Validatable] 
    public class User
    {
        public long id { get; set; }
        
        [Required]
        [StringLength(12, ErrorMessage = "username must be between 4 and 12", MinimumLength = 4)]
        public string username { get; set; }
        [Required]
        [StringLength(5, ErrorMessage = "password must be between 5 and 16", MinimumLength = 16)]
        public string password { get; set; }
        
        public long securitylevel { get; set; }


       
    }
}