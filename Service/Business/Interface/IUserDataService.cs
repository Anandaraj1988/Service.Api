using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceApi.Business.Interface
{
    using Api.Model.V1;
    public interface IUserDataService
    {
        Task<IEnumerable<UserResult>> CreateUserAsync(CreateUserRequest createUserRequest);
        Task<LoginResult> UserLoginAsync(LoginRequest loginRequest);
    }
}
