using System;
using System.Collections.Generic;

namespace MusicStore.Database.Entities
{
    public partial class Inventory
    {
        public string Id { get; set; }
        public string AlbumId { get; set; }
        public int? QtyAvailable { get; set; }
        public long? PurchasePrice { get; set; }
        public long? SalePrice { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Album Album { get; set; }
        public virtual Orderdetail Orderdetail { get; set; }
    }
}
