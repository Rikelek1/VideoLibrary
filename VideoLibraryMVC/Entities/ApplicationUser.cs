using Microsoft.AspNetCore.Identity;

namespace VideoLibraryMVC.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? Salutation { get; set; }
        public int? Age { get; set; }
        public virtual List<Video> Videos { get; set; }
    }
}
