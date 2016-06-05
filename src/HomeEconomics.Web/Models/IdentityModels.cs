using System;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Identity.MongoDB;
using Microsoft.AspNet.Identity;
using MongoDB.Driver;

namespace HomeEconomics.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Hometown { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IDisposable
    {
        private MongoClient _client;
        private IMongoDatabase _database;

        public ApplicationDbContext()
        {
            var url = ConfigurationManager.ConnectionStrings["home-economics"]?.ConnectionString ?? "mongodb://localhost:27017/home-economics";
            var name = ConfigurationManager.AppSettings["identity:database"] ?? url.Substring(url.LastIndexOf('/') + 1);

            _client = new MongoClient(url);
            _database = _client.GetDatabase(name);
            Users = GetCollection<ApplicationUser>("Users");
        }

        private IMongoCollection<EntityType> GetCollection<EntityType>(string name)
        {
            var collection = ConfigurationManager.AppSettings[$"identity:{name.ToLowerInvariant()}"] ?? name;
            return _database.GetCollection<EntityType>(collection);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IMongoCollection<ApplicationUser> Users { get; set; }
        public void Dispose()
        {
            ;
        }
    }
}