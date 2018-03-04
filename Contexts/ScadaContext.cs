using BackEnd.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BackEnd.Contexts
{
    public class ScadaContext
    {
        private readonly IMongoDatabase _database = null;

          public ScadaContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

         public IMongoCollection<Projeto> Projeto
        {
            get
            {
                return _database.GetCollection<Projeto>("Projetos");
            }
        }
    }
}