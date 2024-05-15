using System;
using System.Collections.Generic;
using AJS.DVDCentral.PL2;

namespace AJS.DVDCentral.PL2.Entities
{
    public class tblGenre : IEntity
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = null!;

        public string SortField { get { return Description; } }

        public virtual ICollection<tblMovieGenre> tblMovieGenres { get; set; } 
    }
}