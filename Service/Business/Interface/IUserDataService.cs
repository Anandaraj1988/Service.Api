using System.Threading.Tasks;

namespace ServiceApi.Business.Interface
{
    public interface IUserDataService
    {
        Task<bool> CreateUserAsync(string userName, string password, string domain, int userRole);
    }
}
