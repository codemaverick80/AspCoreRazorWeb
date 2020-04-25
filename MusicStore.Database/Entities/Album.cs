using System;
using System.Collections.Generic;

namespace MusicStore.Database.Entities
{
    public partial class Album
    {
        public Album()
        {
            Track = new HashSet<Track>();
        }

        public string Id { get; set; }
        public string AlbumName { get; set; }
        public string ArtistId { get; set; }
        public string GenreId { get; set; }
        public int? Rating { get; set; }
        public int? Year { get; set; }
        public string Label { get; set; }
        public string ThumbnailTag { get; set; }
        public string SmallThumbnail { get; set; }
        public string MediumThumbnail { get; set; }
        public string LargeThumbnail { get; set; }
        public string AlbumUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<Track> Track { get; set; }
    }
}
