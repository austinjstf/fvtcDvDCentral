using System;
using System.Collections.Generic;

namespace AJS.DVDCentral.PL2.Entities
{ 

    public  class tblRating : IEntity
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = null!;

        public string SortField { get { return Description; } }

        public virtual ICollection<tblMovie> tblMovies { get; set; }
    }
}