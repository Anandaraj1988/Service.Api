using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace ServiceApi.DataAccess.Implementation
{
    using Business.Common;
    using Dapper;
    using DataAccess.Model;
    using DataAccess.Interface;

    public class DomainDataProvider : IDomainDataProvider
    {
        private DatabaseSettings _settings;

        public DomainDataProvider(IOptions<DatabaseSettings> settings)
        {
            this._settings = settings.Value;
        }

        #region User Creation Section
        public async Task<Domain> CreateDomainAsync(string name, Guid apiKey)
        {
            using (var connection = new SqlConnection(this._settings.ConnectionString))
            {
                await connection.OpenAsync();
                var resultDomain = await connection.QueryAsync<Domain>(
                    "Admin.dbo.CreateDomain",
                    new
                    {
                        DomainID = Guid.Empty,
                        Name = name,
                        ApiKey = apiKey
                    },
                    commandType: CommandType.StoredProcedure);

                if (resultDomain == null) return null;
                return resultDomain.FirstOrDefault();
            }
        }
        #endregion
    }
}
