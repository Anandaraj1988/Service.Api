using System.Threading.Tasks;
using System.Collections.Generic;

namespace ServiceApi.Business.Implementation
{
    using Interface;
    using AutoMapper;
    using DataAccess.Interface;
    using Api.Model.V1;
    using Business.Common;

    public class UserDataService : IUserDataService
    {
        private readonly IMapper mapper;
        private readonly IUserDataProvider userDataProvider;

        public UserDataService(IMapper _Mapper, IUserDataProvider _UserDataProvider)
        {
            mapper = _Mapper;
            userDataProvider = _UserDataProvider;
        }

        public async Task<IEnumerable<UserResult>> CreateUserAsync(string userName, string password, string domain, int userRole)
        {
            if (!string.IsNullOrEmpty(password))
                password = Helper.EncryptPassword(password);

            var result = await userDataProvider.CreateUserAsync(userName, password, domain, userRole);
            return mapper.Map<IEnumerable<UserResult>>(result);
        }

        public async Task<LoginResult> UserLoginAsync(string userName, string password, string domain)
        {
            if (!string.IsNullOrEmpty(password))
                password = Helper.EncryptPassword(password);

            var result = await userDataProvider.UserLoginAsync(userName, password, domain);
            return mapper.Map<LoginResult>(result);
        }
    }
}
