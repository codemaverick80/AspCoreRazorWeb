using System;
using System.Collections.Generic;

namespace MusicStore.Database.Entities
{
    public partial class Cartdetail
    {
        public string Id { get; set; }
        public string CartId { get; set; }
        public string InventoryId { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
