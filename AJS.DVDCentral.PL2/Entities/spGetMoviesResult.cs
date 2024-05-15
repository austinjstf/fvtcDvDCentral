using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJS.DVDCentral.PL2.Entities
{
    public class spGetMoviesResult : IEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public Guid FormatId { get; set; }

        public Guid DirectorId { get; set; }

        public Guid RatingId { get; set; }

        public double Cost { get; set; }

        public int Quantity { get; set; }

        public string SortField { get { return Description; } }

        public string RatingDescription { get; set; }
        public string FormatDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
