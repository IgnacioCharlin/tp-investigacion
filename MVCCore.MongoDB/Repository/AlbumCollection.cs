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
            Collection.DeleteOneAsync(filter);
        }

        public List<Album> GetAllAlbums()
        {
            var query = Collection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }

        public Album getAlmbumById(string id)
        {
            var album = Collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;
            return album;
        }

        public void InsertAlbum(Album album)
        {
            Collection.InsertOneAsync(album);
        }

        public void updateAlbum(Album album)
        {
            var filter = Builders<Album>.Filter.Eq(s=> s.Id,album.Id);
            Collection.ReplaceOneAsync(filter, album);
        }
    }
}
