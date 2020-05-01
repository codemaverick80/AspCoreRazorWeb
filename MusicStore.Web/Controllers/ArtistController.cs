using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MusicStore.Services.Contracts;
using Newtonsoft.Json;
using MusicStore.Web.Dtos.Response;
using MusicStore.Web.Dtos.Request.Create;
using MusicStore.Database.Entities;

namespace MusicStore.Web.Controllers
{
    [Route("api/artist")]
    [ApiController]
    public class ArtistController : Controller
    {
        private IMapper _mapper;
        private IArtistRepository _artistRepo;

        public ArtistController(IMapper mapper, IArtistRepository artistRepository)
        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _artistRepo = artistRepository ?? throw new ArgumentNullException(nameof(artistRepository));
        }


        //[HttpGet]        
        //public async Task<ActionResult<ArtistGetResponse[]>> GetAll()
        //{
        //    try
        //    {
        //        var artistFromRepo = _mapper.Map<ArtistGetResponse[]>(await _artistRepo.GetArtistsAsync(1, 10));

        //        throw new Exception("Oops! Exception while fetching artist from database");
        //        return Json(new { data = artistFromRepo });

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal Server Error!");
        //    }

        //}



        /*
         * Global Exception Handling (startup.cs) (No need to use try-catch block in every method)
         * 
         *   By Using Exception Middleware Extension => app.ConfigureExceptionHandler();
         *   Or,
         *   By Using Custom Exception Middleware => app.ConfigureCustomExceptionMiddleware();
         *
         */
        [HttpGet]       
        public async Task<IActionResult> GetAll()
        {            
            var artistFromRepo = _mapper.Map<ArtistGetResponse[]>(await _artistRepo.GetArtistsAsync(1, 10));

            //// Just for exception testing purpose
            throw new Exception("Oops! Exception while fetching artist from database");

            return Json(new { data = artistFromRepo });


        }

        //// url: /api/artist/createartist
        [HttpPost("createartist", Name = "CreateArtist")]        
        public async Task<IActionResult> CreateArtist([FromBody]ArtistCreateRequest artistCreateRequest)
        {    

           var artistEntity = _mapper.Map<Artist>(artistCreateRequest);
            artistEntity.Id = Guid.NewGuid().ToString();
            _artistRepo.CreateArtist(artistEntity);
            await _artistRepo.SaveAsync();
               

            return Json(new {data =artistEntity, message="Success"});

        }

        //// url: /api/artist/createartist_a
        [HttpPost("createartist_a", Name = "CreateArtist_a")]        
        public async Task<ActionResult<ArtistGetResponse>> CreateArtistA([FromBody]ArtistCreateRequest artistCreateRequest)
        {            
           
            return Ok();
          
        }



    }
}
