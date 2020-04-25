using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicStore.Services.Contracts;
using MusicStore.Web.Dtos.Request.Delete;
using AutoMapper;
using System;

namespace MusicStore.Web.Pages.Genre
{
    public class DeleteModel : PageModel
    {
        private readonly IGenreRepository _genreRepository;
        private IMapper _mapper;

        public DeleteModel(IGenreRepository genreRepository, IMapper mapper )
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public GenreDeleteRequest GenreDeleteRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GenreDeleteRequest = _mapper.Map<GenreDeleteRequest>(await _genreRepository.GetGenreByIdAsync(new Guid(id)));

            if (GenreDeleteRequest == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var genreFromRepo = await _genreRepository.GetGenreByIdAsync(new Guid(id));

            if (genreFromRepo != null)
            {                
                _genreRepository.DeleteGenre(genreFromRepo);
                await _genreRepository.SaveAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
