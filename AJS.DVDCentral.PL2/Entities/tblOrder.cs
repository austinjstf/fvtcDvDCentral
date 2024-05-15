using System;
using System.Collections.Generic;

namespace AJS.DVDCentral.PL2.Entities
{
    public class tblOrder : IEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public DateTime ShipDate { get; set; }

        public string SortField { get { return User.LastName; } }
        public virtual ICollection<tblOrderItem> OrderItems { get; set; }
        public virtual tblCustomer Customer { get; set; }
        public virtual tblCustomer User { get; set; }

    }
}