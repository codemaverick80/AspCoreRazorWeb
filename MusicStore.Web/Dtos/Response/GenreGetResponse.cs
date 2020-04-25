using System;
namespace MusicStore.Web.Dtos.Response
{
    public class GenreGetResponse
    {
        public string Id { get; set; }        
        public string Name { get; set; }
        public virtual string Description { get; set; }
        
    }
}
