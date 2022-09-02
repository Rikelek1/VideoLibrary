using VideoLibraryMVC.Entities;
using VideoLibraryMVC.Services.Interfaces;

namespace VideoLibraryMVC.Services
{
    public class CrapVideoService : IVideoService
    {
        public ICollection<ApplicationUser> GetAllUsers()
        {
            return new List<ApplicationUser>();
        }
    }
}
