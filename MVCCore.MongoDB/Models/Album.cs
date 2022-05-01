using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MVCCore.MongoDB.Models
{
    public class Album
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string AlbumName { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }   
    }
}
