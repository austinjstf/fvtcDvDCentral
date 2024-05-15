using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJS.DVDCentral.BL.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid FormatId { get; set; }
        public Guid DirectorId { get; set; }
        public Guid RatingId { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }

        [DisplayName("Director Full Name")]
        public string DirectorFullName { get; set; }

        [DisplayName("Rating Description")]
        public string RatingDescription { get; set; }

        [DisplayName("Format Description")]
        public string FormatDescription { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}
