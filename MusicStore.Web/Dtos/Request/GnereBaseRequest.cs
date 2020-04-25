using System;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Web.Dtos.Request
{
    public abstract class GenreBaseRequest
    {
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage ="Genre name is required!")]        
        public string Name { get; set; }

        public virtual string Description { get; set; }

        //public bool IsDeleted { get; set; }
    }
}
