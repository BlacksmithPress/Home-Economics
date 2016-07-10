using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using Arango.Client;
using Autofac;

namespace HomeEconomics.Data.ArangoDB
{
    public class Module : Autofac.Module
    {
        private ADatabase _database;
        private Dictionary<string,ConnectionString> _connections = new Dictionary<string, ConnectionString>();
        private ADatabase _system;

        protected override void Load(ContainerBuilder builder)
        {
            foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
            {
                if (string.Compare(connectionString.ProviderName, "arangodb", StringComparison.CurrentCultureIgnoreCase) == 0)
                {
                    var connection = new ConnectionString(connectionString);
                    _connections.Add(connection.Alias, connection);

                    if (!ASettings.HasConnection(connection.Alias))
                    {
                        ASettings.AddConnection(connection.Alias, connection.Host, connection.Port, connection.IsSecured,
                            connection.DatabaseName, connection.Username, connection.Password);
                    }
                }
            }

            var system = _connections["system"];
            if (!ASettings.HasConnection(system.Alias))
                throw new InvalidDataException($"The _system database cannot be accessed.");

            _system = new ADatabase(system.Alias);

            var homeec = _connections["home-economics"];
            if (ASettings.HasConnection(homeec.Alias))
            {
                var databases = _system.GetAccessibleDatabases();
                if (databases.Success && databases.HasValue && databases.Value.Contains(homeec.DatabaseName))
                {
                    _database = new ADatabase(homeec.Alias);
                }
                else
                {
                    var result = _system.Create(homeec.DatabaseName);
                    if (result.Success)
                        _database = new ADatabase(homeec.Alias);
                }
            }
            if (_database != null && _database.GetCurrent().Success)
            {
                Database.Instance = new Database(_database, builder);
                builder.RegisterInstance(Database.Instance).As<IDatabase>();
            }
            else
                throw new Exception($"No database named {homeec.DatabaseName} was found or could be created.");

        }
    }
}
