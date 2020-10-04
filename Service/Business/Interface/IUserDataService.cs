using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceApi.Business.Interface
{
    using Api.Model.V1;
    public interface IUserDataService
    {
        Task<IEnumerable<User>> CreateUserAsync(string userName, string password, string domain, int userRole);
        Task<LoginResult> UserLoginAsync(string userName, string password);
    }
}
