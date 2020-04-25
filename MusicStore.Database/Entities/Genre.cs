using System;
using System.Collections.Generic;

namespace MusicStore.Database.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            Album = new HashSet<Album>();
        }

        public string Id { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}
