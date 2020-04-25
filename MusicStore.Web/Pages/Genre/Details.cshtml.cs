using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicStore.Services.Contracts;
using MusicStore.Web.Dtos.Response;
using AutoMapper;

namespace MusicStore.Web.Pages.Genre
{
    public class DetailsModel : PageModel
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public DetailsModel(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public GenreGetResponse GenreResponse { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GenreResponse = _mapper.Map<GenreGetResponse>(await _genreRepository.GetGenreByIdAsync(new Guid(id)));
            
            if (GenreResponse == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
