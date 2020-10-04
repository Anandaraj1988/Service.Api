using Dapper;
using Microsoft.Extensions.Options;
using ServiceApi.Business.Common;
using ServiceApi.DataAccess.Interface;
using ServiceApi.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
        public async Task<IEnumerable<User>> CreateUserAsync(string userName, string password, string domain, int userRole)
        {
            using (var connection = new SqlConnection(this._settings.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<User>(
                    "Contacts.dbo.CreateUser",
                    new
                    {
                        UserID = Guid.Empty,
                        UserName = userName,
                        Password = password,
                        UserRole = userRole,
                        Domain = domain,
                        EmailID = string.Empty
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<LoginResult> UserLoginAsync(string userName, string password)
        {
            string userID = string.Empty;
            using (var connection = new SqlConnection(this._settings.ConnectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<User>(
                    "Contacts.dbo.CheckRegisteredUser",
                    new
                    {
                        UserName = userName,
                        Password = password
                    },
                    commandType: CommandType.StoredProcedure);

                if (result != null)
                {
                    userID = result.FirstOrDefault().UserID.ToString();

                }
            }
            return new LoginResult()
            {
                IsAuthenticated = !string.IsNullOrEmpty(userID),
                UserID = userID
            };
        }
        #endregion
    }
}
