using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceApi.DataAccess.Interface
{
    using Model;

    public interface IUserDataProvider
    {
        Task<IEnumerable<UserResult>> CreateUserAsync(CreateUserRequest createUserRequest);
        Task<LoginResult> UserLoginAsync(LoginRequest loginRequest);
    }
}
