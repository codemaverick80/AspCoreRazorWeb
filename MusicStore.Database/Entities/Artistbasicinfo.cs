using System;
using System.Collections.Generic;

namespace MusicStore.Database.Entities
{
    public partial class Artistbasicinfo
    {
        public string ArtistId { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        public string AlsoKnownAs { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
