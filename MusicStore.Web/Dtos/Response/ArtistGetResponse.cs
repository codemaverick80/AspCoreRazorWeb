using System;
namespace MusicStore.Web.Dtos.Response
{
    public class ArtistGetResponse
    {        
        public string Id { get; set; }
        public string Name { get; set; }
        public string YearActive { get; set; }
        public string Biography { get; set; }
        public string ThumbnailTag { get; set; }
        public string SmallThumbnail { get; set; }
        public string LargeThumbnail { get; set; }      
    }
}
