using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MusicStore.Services.Contracts;
using Newtonsoft.Json;
using MusicStore.Web.Dtos.Response;

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

        [HttpGet]
        // GET: /<controller>/
        public async Task<IActionResult> GetAll()
        {
            var artistFromRepo = _mapper.Map<ArtistGetResponse[]>(await _artistRepo.GetArtistsAsync(1, 10));

            return Json(new { data = artistFromRepo });
        }
    }
}
