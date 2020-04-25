using System;
using AutoMapper;
using MusicStore.Database.Entities;
using MusicStore.Web.Dtos.Request.Create;
using MusicStore.Web.Dtos.Request.Delete;
using MusicStore.Web.Dtos.Request.Update;
using MusicStore.Web.Dtos.Response;

namespace MusicStore.Web.MappingProfiles
{
    public class GenreMapping : Profile
    {

        /*
         * DTO or Data Transfer Object serves the purpose to transfer data from the server to the client.
         * 
         * NuGet Package Required
         *   AutoMapper.Extensions.Microsoft.DependencyInjection
         */

        public GenreMapping()
        {
            /* Mapps Database entity to Dto  */

            CreateMap<Genre, GenreGetResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GenreName));


            /* Mapps Dto to Database entity */

            CreateMap<GenreCreateRequest, Genre>()
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Name));


            /* Mapps Dto to Database entity */

            CreateMap<GenreUpdateRequest, Genre>()
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Name));

            CreateMap<Genre, GenreUpdateRequest>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GenreName));


            CreateMap<GenreDeleteRequest, Genre>()
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Name));

            CreateMap<Genre, GenreDeleteRequest>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GenreName));


        }
    }
}
