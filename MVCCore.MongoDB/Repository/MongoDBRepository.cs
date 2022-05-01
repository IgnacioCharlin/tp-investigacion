using MongoDB.Driver;

namespace MVCCore.MongoDB.Repository
{
    public class MongoDBRepository
    {

        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            client = new MongoClient("mongodb://localhost:27017");

            db = client.GetDatabase("MusicCatalog");
        }

    }
}
