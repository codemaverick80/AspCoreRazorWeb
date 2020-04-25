using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Database.Entities;
using MusicStore.Services.Contracts;

namespace MusicStore.Services.Repositories
{
    public class AlbumRepository : RepositoryBase<Album>, IAlbumRespository
    {
        public AlbumRepository(MusicStoreDbContext context):base(context){}

        public async Task<bool> AlbumExistsAsync(Guid id) => await _context.Album.AnyAsync(a => a.Id == id.ToString());

        public void CreateAlbum(Album album) => Create(album);

        public void DeleteAlbum(Album album) => Delete(album);

        public async Task<Album> GetAlbumByIdAsync(Guid id) => await GetByCondition(a => a.Id == id.ToString()).FirstOrDefaultAsync();
        
        public async Task<IEnumerable<Album>> GetAllAlbumsAsync() => await GetAll().ToListAsync();
        
        public void UpdateAlbum(Album album) => Update(album);



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
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
