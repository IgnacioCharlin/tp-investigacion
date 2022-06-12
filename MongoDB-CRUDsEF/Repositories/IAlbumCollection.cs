﻿using MongoDB_CRUDsEF.Models;
using System.Collections.Generic;

namespace MongoDB_CRUDsEF.Repositories
{
    public interface IAlbumCollection
    {
        void InsertAlbum(Album album);
        void UpdateAlbum (Album album);
        void DeleteAlbum (string id);
        List<Album> GetAllAlbums();
        Album GetAlbumById(string id);
      
    }
}
