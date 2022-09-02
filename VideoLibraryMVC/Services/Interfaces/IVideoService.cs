using VideoLibraryMVC.Entities;

namespace VideoLibraryMVC.Services.Interfaces
{
    public interface IVideoService
    {
        ICollection<ApplicationUser> GetAllUsers();
    }
}
