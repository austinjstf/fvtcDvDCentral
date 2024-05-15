using AJS.DVDCentral.BL;
using AJS.DVDCentral.BL.Models;

namespace AJS.DVDCentral.UI.ViewModels
{
    public class MovieVM
    {
        public Movie movie {  get; set; } = new Movie();

        public List<Genre> genres { get; set; } = new List<Genre>();

        public List<Director> directors { get; set; } = new List<Director>();

        public List<Rating> ratings { get; set; } = new List<Rating>();

        public List<Format> formats { get; set; } = new List<Format>();

        public IFormFile File { get; set; }

        public IEnumerable<int> MovieGenreIds { get; set; }
       
    }
}
