using MVCCore.MongoDB.Models;
using System.Collections.Generic;

namespace MVCCore.MongoDB.Repository
{
    public interface IAlbumCollection
    {
        void InsertAlbum(Album album);
        void UpdateAlbum (Album album);
        void DeleteAlbum (string id);
        List<Album> GetAllAlbums();
        Album GetAlmbumById(string id);

    }
}
