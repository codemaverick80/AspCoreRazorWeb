using System;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Web.Dtos.Request
{
    public class ArtistBaseRequest
    {

        public string Id { get; set; }
        [Required(ErrorMessage ="Artist Name required")]
        public virtual string ArtistName { get; set; }
        public virtual string YearActive { get; set; }
        public virtual string Biography { get; set; }
        public virtual string ThumbnailTag { get; set; }
        public virtual string SmallThumbnail { get; set; }
        public virtual string LargeThumbnail { get; set; }
     
        
    }
}
