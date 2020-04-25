using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicStore.Services.Contracts;
using MusicStore.Web.Dtos.Response;

namespace MusicStore.Web.Pages.Genre
{
    public class IndexModel : PageModel
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public IndexModel(IGenreRepository genreRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
        }

        public IList<GenreGetResponse> Genres { get;set; }

        public async Task OnGetAsync()
        {
            Genres = _mapper.Map<GenreGetResponse[]>(await _genreRepository.GetAllGenresAsync());
        }
    }
}
