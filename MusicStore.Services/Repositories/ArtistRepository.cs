using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Database.Entities;
using MusicStore.Services.Contracts;

namespace MusicStore.Services.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private MusicStoreDbContext _context;

        //public ArtistRepository(MusicStoreDbContext context) : base(context) { }

        //public async Task<bool> ArtistExistsAsync(Guid id) => await _context.Artist.AnyAsync(a => a.Id == id.ToString());

        //public void CreateArtist(Artist artist) => Create(artist);

        //public void DeleteArtist(Artist artist)=> Delete(artist);              

        //public async Task<IEnumerable<Artist>> GetAllArtistsAsync() => await GetAll().ToListAsync();

        //public async Task<Artist> GetArtistByIdAsync(Guid id) => await GetByCondition(a => a.Id == id.ToString()).FirstOrDefaultAsync();

        //public void UpdateArtist(Artist artist) => Update(artist);        


        public ArtistRepository(MusicStoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

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



        public async Task<IEnumerable<Artist>> GetArtistsAsync( int pageIndex=1, int pageSize=10)
        {
            IQueryable<Artist> query = _context.Set<Artist>();

            var result = query
                //.Include(a => a.Artistbasicinfo)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking();

            return await result.ToListAsync();
        }

        public async Task<Artist> GetArtistAsync(Guid id)
        {
            IQueryable<Artist> query = _context.Set<Artist>();

            var result = query
                //.Include(a => a.Artistbasicinfo)
                .Where(a => a.Id == id.ToString());

            return await result.FirstOrDefaultAsync();
        }

        public async Task<bool> ArtistExistsAsync(Guid id)
        {
            return await _context.Set<Artist>()
                .AnyAsync(a => a.Id == id.ToString());
        }

        public void CreateArtist(Artist artist)
        {
            if (artist == null) { throw new ArgumentNullException(nameof(artist)); }
            _context.Add(artist);
        }

        public void UpdateArtist(Artist artist)
        {
            if (artist == null) { throw new ArgumentNullException(nameof(artist)); }
            _context.Set<Artist>().Update(artist);
        }

        public void DeleteArtist(Artist artist)
        {
            _context.Artist.Remove(artist);
            if (artist.Artistbasicinfo != null)
            {
                _context.Artistbasicinfo.Remove(artist.Artistbasicinfo);
            }
        }

       
    }
}
