using System.Threading.Tasks;

namespace ServiceApi.Business.Implementation
{
    using DataAccess.Interface;
    using Business.Interface;
    using AutoMapper;

    public class UserDataService : IUserDataService
    {
        private readonly IMapper mapper;
        private readonly IUserDataProvider userDataProvider;

        public UserDataService(IMapper _Mapper, IUserDataProvider _UserDataProvider)
        {
            mapper = _Mapper;
            userDataProvider = _UserDataProvider;
        }

        public async Task<bool> CreateUserAsync(string userName, string password, string domain, int userRole)
        {
            var result = await userDataProvider.CreateUserAsync(userName, password, domain, userRole);
            return true;
        }
    }
}
