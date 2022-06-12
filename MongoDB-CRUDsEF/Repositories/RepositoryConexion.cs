using MongoDB.Driver;

namespace MongoDB_CRUDsEF.Repositories
{
    public class RepositoryConexion
    {
        public MongoClient client;

        public IMongoDatabase db;

        public RepositoryConexion()
        {
            client = new MongoClient("mongodb://localhost:27017");

            db = client.GetDatabase("MusicCatalog");
        }
    }
}
