using Microsoft.AspNetCore.Mvc.Rendering;
using VideoLibraryMVC.Entities;

namespace VideoLibraryMVC.ViewModels
{
    public class VideosIndexViewModel
    {
        public IEnumerable<Video> Videos { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }

        public int VideoId { get; set; }
        public string UserId { get; set; }
    }
}
