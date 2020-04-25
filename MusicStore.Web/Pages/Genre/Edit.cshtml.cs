using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicStore.Services.Contracts;
using AutoMapper;
using MusicStore.Web.Dtos.Request.Update;
//https://www.learnrazorpages.com/razor-pages/model-binding#preventing-overposting-or-mass-assignment-attacks
namespace MusicStore.Web.Pages.Genre
{
    public class EditModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public EditModel(IGenreRepository genreRepository, IMapper mapper)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        [BindProperty]
        public GenreUpdateRequest GenreUpdateRequest { get; set; }

        //[BindProperty(SupportsGet =true)]
        //public string Id { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            

            if (id == null)
            {
                return NotFound();
            }

            GenreUpdateRequest = _mapper.Map<GenreUpdateRequest>(await _genreRepository.GetGenreByIdAsync(new Guid(id)));

            if (GenreUpdateRequest == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!await _genreRepository.GenreExistsAsync(new Guid(GenreUpdateRequest.Id)))
            {
                return NotFound();
            }

            try
            {
                var genreFromRepo = await _genreRepository.GetGenreByIdAsync(new Guid(GenreUpdateRequest.Id));
                _mapper.Map(GenreUpdateRequest, genreFromRepo);
                _genreRepository.UpdateGenre(genreFromRepo);
                await _genreRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToPage("./Index");
        }

       
        public async Task<IActionResult> OnPostViewAsync(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            GenreUpdateRequest = _mapper.Map<GenreUpdateRequest>(await _genreRepository.GetGenreByIdAsync(new Guid(id)));

            if (GenreUpdateRequest == null)
            {
                return NotFound();
            }

            return Page();
        }       
        
    }
}
