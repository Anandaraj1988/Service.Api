using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceApi.DataAccess.Implementation
{
    using Business.Common;
    using DataAccess.Interface;
    using DataAccess.Model;

    public class UserDataProvider : IUserDataProvider
    {
        private DatabaseSettings _settings;

        public UserDataProvider(IOptions<DatabaseSettings> settings)
        {
            this._settings = settings.Value;
        }

        #region User Creation Section
        public async Task<IEnumerable<UserResult>> CreateUserAsync(CreateUserRequest createUserRequest)
        {
            using (var connection = new SqlConnection(this._settings.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<UserResult>(
                    "Admin.dbo.CreateUser",
                    createUserRequest,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<LoginResult> UserLoginAsync(LoginRequest loginRequest)
        {
            using (var connection = new SqlConnection(this._settings.ConnectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<LoginResult>(
                    "Admin.dbo.CheckRegisteredUser",
                    loginRequest,
                    commandType: CommandType.StoredProcedure);

                return result.Any() ? result.FirstOrDefault() : null;
            }
        }
        #endregion
    }
}
