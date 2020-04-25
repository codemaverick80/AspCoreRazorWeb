using System;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Web.Dtos.Request.Update
{
    public class GenreUpdateRequest : GenreBaseRequest
    {

        [Required(ErrorMessage="Genre Description required!")]
        public override string Description { get => base.Description; set => base.Description = value; }

    }
}
