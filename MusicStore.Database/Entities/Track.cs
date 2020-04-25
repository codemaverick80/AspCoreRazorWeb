using System;
using System.Collections.Generic;

namespace MusicStore.Database.Entities
{
    public partial class Track
    {
        public string Id { get; set; }
        public string TrackName { get; set; }
        public string AlbumId { get; set; }
        public string Composer { get; set; }
        public string Performer { get; set; }
        public string Featuring { get; set; }
        public string Duration { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Album Album { get; set; }
    }
}
