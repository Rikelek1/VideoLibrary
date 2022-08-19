using Microsoft.AspNetCore.Identity;

namespace VideoLibraryMVC.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Salutation { get; set; }
        public int? Age { get; set; }
    }
}
