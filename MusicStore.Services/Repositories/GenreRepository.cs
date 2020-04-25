using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Database.Entities;
using MusicStore.Services.Contracts;

namespace MusicStore.Services.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(MusicStoreDbContext context):base(context) {}

        public void CreateGenre(Genre genre) => Create(genre);        

        public void DeleteGenre(Genre genre) => Delete(genre);

        public async Task<bool> GenreExistsAsync(Guid id) => await _context.Genre.AnyAsync(l => l.Id == id.ToString());        

        public async Task<IEnumerable<Genre>> GetAllGenresAsync() => await GetAll().ToListAsync();

        //// public async Task<IEnumerable<Genre>> GetAllGenresAsync() => await GetAll().OrderBy(g => g.GenreName).ToListAsync();
       
        public async Task<Genre> GetGenreByIdAsync(Guid id) => await GetByCondition(g => g.Id == id.ToString()).FirstOrDefaultAsync();       

        public void UpdateGenre(Genre genre) => Update(genre);


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()>0);
        }
    }
}
