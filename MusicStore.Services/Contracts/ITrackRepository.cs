using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Database.Entities;

namespace MusicStore.Services.Contracts
{
    public interface ITrackRepository:IDisposable
    {
        Task<IEnumerable<Track>> GetAllTracksAsync();
        Task<Track> GetTrackByIdAsync(Guid id);
        Task<bool> TrackExistsAsync(Guid id);
        void CreateTrack(Track track);
        void UpdateTrack(Track track);
        void DeleteTrack(Track track);
        Task<bool> SaveAsync();
    }
}
