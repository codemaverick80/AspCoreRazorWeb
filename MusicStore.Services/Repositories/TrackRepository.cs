using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Database.Entities;
using MusicStore.Services.Contracts;

namespace MusicStore.Services.Repositories
{
    public class TrackRepository: RepositoryBase<Track>, ITrackRepository
    {
        public TrackRepository(MusicStoreDbContext context):base(context)
        {}

        public void CreateTrack(Track track) => Create(track);

        public void DeleteTrack(Track track) => Delete(track);

        public async Task<IEnumerable<Track>> GetAllTracksAsync() => await GetAll().ToListAsync();

        public async Task<Track> GetTrackByIdAsync(Guid id) => await GetByCondition(t => t.Id == id.ToString()).FirstOrDefaultAsync();
        
        public async Task<bool> TrackExistsAsync(Guid id) => await _context.Track.AnyAsync(t => t.Id == id.ToString());
        
        public void UpdateTrack(Track track) => Update(track);
        

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
