using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HomeEconomics.Data.Entities;
using HomeEconomics.Data.Repositories;
using HomeEconomics.Types;
using MongoDB.Driver;

namespace HomeEconomics.Data
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
        }
    }
}
