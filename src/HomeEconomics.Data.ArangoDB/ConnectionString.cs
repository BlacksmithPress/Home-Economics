using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HomeEconomics.Data.ArangoDB
{
    public class ConnectionString
    {
        private ConnectionStringSettings _settings;

        public ConnectionString(ConnectionStringSettings settings)
        {
            _settings = settings;
            Alias = _settings.Name;
            Provider = _settings.ProviderName ?? "ArangoDB";
            var uri = new Uri(_settings.ConnectionString);
            Host = uri.Host;
            Port = uri.IsDefaultPort ? 8529 : uri.Port;
            IsSecured = !string.IsNullOrEmpty(uri.UserInfo);

            if (uri.UserInfo.Contains(':'))
            {
                var parts = uri.UserInfo.Split(':');
                Username = parts[0];
                Password = parts[1];
            }
            else
                Username = uri.UserInfo;

            if (string.IsNullOrEmpty(uri.AbsolutePath))
                DatabaseName = string.Empty;
            else
            {
                if (uri.AbsolutePath[0] == '/')
                    DatabaseName = uri.AbsolutePath.Substring(1);
                else
                    DatabaseName = uri.AbsolutePath;
            }
        }

        public ConnectionString() { }

        public string Alias { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool IsSecured { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Provider { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ConnectionString)
                return ((ConnectionString) obj).ToString().Equals(ToString(), StringComparison.CurrentCultureIgnoreCase);
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            var password = !string.IsNullOrEmpty(Password) ? $":{Password}" : string.Empty;
            var userinfo = $"{Username}{password}";
            if (!string.IsNullOrEmpty(userinfo))
                userinfo += "@";
            var port = (Port == 8529) ? string.Empty : $":{Port}";
            var provider = string.IsNullOrEmpty(Provider) ? "arangodb" : Provider.ToLower();
            return $"{provider}://{userinfo}{Host}{port}/{DatabaseName}";
        }
    }
}
