using System;
using System.Collections.Generic;

namespace MusicStore.Database.Entities
{
    public partial class Artist
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }

        public string Id { get; set; }
        public string ArtistName { get; set; }
        public string YearActive { get; set; }
        public string Biography { get; set; }
        public string ThumbnailTag { get; set; }
        public string SmallThumbnail { get; set; }
        public string LargeThumbnail { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Artistbasicinfo Artistbasicinfo { get; set; }
        public virtual ICollection<Album> Album { get; set; }
    }
}
