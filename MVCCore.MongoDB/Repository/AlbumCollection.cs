using MongoDB.Bson;
using MongoDB.Driver;
using MVCCore.MongoDB.Models;
using System.Collections.Generic;

namespace MVCCore.MongoDB.Repository
{
    public class AlbumCollection : IAlbumCollection
    {

        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Album> Collection;


        public AlbumCollection()
        {
            Collection = _repository.db.GetCollection<Album>("Albums");
        }

        public void DeleteAlbum(string id)
        {
            var filter = Builders<Album>.Filter.Eq(s => s.Id, id);
            Collection.DeleteOne(filter);
        }

        public List<Album> GetAllAlbums()
        {
            return Collection.Find(new BsonDocument()).ToList();
        }

        public Album GetAlmbumById(string id)
        {
            var album = Collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).First();
            return album;
        }

        public void InsertAlbum(Album album)
        {
            Collection.InsertOne(album);
        }

        public void UpdateAlbum(Album album)
        {
            var filter = Builders<Album>.Filter.Eq(s=> s.Id,album.Id);
            Collection.ReplaceOne(filter, album);
        }
    }
}
