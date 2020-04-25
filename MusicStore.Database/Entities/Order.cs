using System;
using System.Collections.Generic;

namespace MusicStore.Database.Entities
{
    public partial class Order
    {
        public Order()
        {
            Orderdetail = new HashSet<Orderdetail>();
        }

        public string Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Orderdetail> Orderdetail { get; set; }
    }
}
