using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Database.Entities;

namespace MusicStore.Services.Contracts
{
    public interface IAlbumRespository: IDisposable
    {
        Task<IEnumerable<Album>> GetAllAlbumsAsync();
        Task<Album> GetAlbumByIdAsync(Guid id);
        Task<bool> AlbumExistsAsync(Guid id);
        void CreateAlbum(Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(Album album);
        Task<bool> SaveAsync();
    }
}
