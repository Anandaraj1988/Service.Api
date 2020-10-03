using System.Threading.Tasks;

namespace ServiceApi.DataAccess.Interface
{
    public interface IUserDataProvider
    {
        Task<bool> CreateUserAsync(string userName, string password, string domain, int userRole);
    }
}
