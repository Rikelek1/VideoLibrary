using VideoLibraryMVC.Data;
using VideoLibraryMVC.Entities;
using VideoLibraryMVC.Services.Interfaces;

namespace VideoLibraryMVC.Services
{
    public class VideoService : IVideoService
    {
        private readonly ApplicationDbContext _context;

        public VideoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<ApplicationUser> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
