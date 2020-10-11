using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceApi.DataAccess.Interface
{
    using Model;

    public interface IUserDataProvider
    {
        Task<IEnumerable<UserResult>> CreateUserAsync(string userName, string password, string domain, int userRole);
        Task<LoginResult> UserLoginAsync(string userName, string password, string domain);
    }
}
