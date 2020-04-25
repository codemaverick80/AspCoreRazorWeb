using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Database.Entities;

namespace MusicStore.Services.Contracts
{
    public interface IArtistRepository :IDisposable
    {
        Task<IEnumerable<Artist>> GetArtistsAsync(int pageIndex=1,int pageSize=10);
        Task<Artist> GetArtistAsync(Guid id);
        Task<bool> ArtistExistsAsync(Guid id);
        void CreateArtist(Artist artist);
        void UpdateArtist(Artist artist);
        void DeleteArtist(Artist artist);
        Task<bool> SaveAsync();

    }
}
