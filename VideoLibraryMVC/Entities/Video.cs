using System.ComponentModel.DataAnnotations;

namespace VideoLibraryMVC.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        public int Stock { get; set; }
        public virtual List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
