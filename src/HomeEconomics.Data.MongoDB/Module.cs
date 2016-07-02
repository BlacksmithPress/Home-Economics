using System.Configuration;
using Autofac;
using MongoDB.Driver;

namespace HomeEconomics.Data.MongoDB
{
    public class Module : Autofac.Module
    {
        private MongoClient _client;
        private IMongoDatabase _database;

        protected override void Load(ContainerBuilder builder)
        {
            var url = ConfigurationManager.ConnectionStrings["home-economics"]?.ConnectionString ?? "mongodb://localhost:27017/home-economics";
            var name = ConfigurationManager.AppSettings["database"] ?? url.Substring(url.LastIndexOf('/') + 1);

            _client = new MongoClient(url);
            _database = _client.GetDatabase(name);

            Database.Instance = new Database(_database, builder);
            builder.RegisterInstance(Database.Instance).As<IDatabase>();
        }
    }
}
