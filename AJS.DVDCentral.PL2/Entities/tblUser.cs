using System;
using System.Collections.Generic;

namespace AJS.DVDCentral.PL2.Entities
{ 

    public  class tblUser : IEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string SortField { get { return LastName; } }

        public virtual ICollection<tblOrder> Orders { get; set; }
    }
}