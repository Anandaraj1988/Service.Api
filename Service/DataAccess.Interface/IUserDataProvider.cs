using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceApi.DataAccess.Interface
{
    using Model;

    public interface IUserDataProvider
    {
        Task<IEnumerable<User>> CreateUserAsync(string userName, string password, string domain, int userRole);
        Task<LoginResult> UserLoginAsync(string userName, string password);
    }
}
