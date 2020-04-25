using System;
using AutoMapper;
using MusicStore.Database.Entities;
using MusicStore.Web.Dtos.Response;

namespace MusicStore.Web.MappingProfiles
{
    public class ArtistMapping : Profile
    {
        public ArtistMapping()
        {

            /* Mapps Database entity Artist to ArtistGetResponse Dto  */

            CreateMap<Artist, ArtistGetResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ArtistName));


        }
    }
}
