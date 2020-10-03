using Dapper;
using Microsoft.Extensions.Options;
using ServiceApi.Business.Common;
using ServiceApi.DataAccess.Interface;
using ServiceApi.DataAccess.Model;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ServiceApi.DataAccess.Implementation
{
    public class UserDataProvider : IUserDataProvider
    {
        private DatabaseSettings _settings;

        public UserDataProvider(IOptions<DatabaseSettings> settings)
        {
            this._settings = settings.Value;
        }

        #region User Creation Section
        public async Task<bool> CreateUserAsync(string userName, string password, string domain, int userRole)
        {
            using (var connection = new SqlConnection(this._settings.ConnectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<User>(
                    "contacts.dbo.createuser",
                    new
                    {
                        UserName = userName,
                        Password = password,
                        UserRole = userRole,
                        Domain = domain
                    },
                    commandType: CommandType.StoredProcedure);
                return true;
            }
        }
        #endregion
    }
}
