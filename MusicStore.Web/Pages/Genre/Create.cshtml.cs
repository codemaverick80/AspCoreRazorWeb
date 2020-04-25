using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicStore.Services.Contracts;
using AutoMapper;
using MusicStore.Web.Dtos.Request.Create;

namespace MusicStore.Web.Pages.Genre
{
    public class CreateModel : PageModel
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public CreateModel(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GenreCreateRequest GenreModel { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entity = _mapper.Map<MusicStore.Database.Entities.Genre>(GenreModel);
            entity.Id = Guid.NewGuid().ToString();                     
           _genreRepository.CreateGenre(entity);
           await _genreRepository.SaveAsync();

            return RedirectToPage("./Index");
        }
    }
}
