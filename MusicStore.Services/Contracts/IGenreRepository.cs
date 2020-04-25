using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Database.Entities;

namespace MusicStore.Services.Contracts
{
    public interface IGenreRepository : IDisposable
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(Guid id);
        Task<bool> GenreExistsAsync(Guid id);
        void CreateGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(Genre genre);
        Task<bool> SaveAsync();
    }
}
