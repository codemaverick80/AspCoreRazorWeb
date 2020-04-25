using System;
using System.Collections.Generic;

namespace MusicStore.Database.Entities
{
    public partial class Orderdetail
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string InventoryId { get; set; }
        public int? Quantity { get; set; }
        public long? UnitPrice { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Order Order { get; set; }
    }
}
