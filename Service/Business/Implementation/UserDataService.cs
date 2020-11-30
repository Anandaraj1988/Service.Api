using System.Threading.Tasks;
using System.Collections.Generic;

namespace ServiceApi.Business.Implementation
{
    using Interface;
    using AutoMapper;
    using DataAccess.Interface;
    using Api.Model.V1;
    using Data = DataAccess.Model;

    public class UserDataService : IUserDataService
    {
        private readonly IMapper mapper;
        private readonly IUserDataProvider userDataProvider;

        public UserDataService(IMapper _Mapper, IUserDataProvider _UserDataProvider)
        {
            mapper = _Mapper;
            userDataProvider = _UserDataProvider;
        }

        public async Task<IEnumerable<UserResult>> CreateUserAsync(CreateUserRequest createUserRequest)
        {
            var request = mapper.Map<Data.CreateUserRequest>(createUserRequest);
            var result = await userDataProvider.CreateUserAsync(request);
            return mapper.Map<IEnumerable<UserResult>>(result);
        }

        public async Task<LoginResult> UserLoginAsync(LoginRequest loginRequest)
        {
            var request = mapper.Map<Data.LoginRequest>(loginRequest);
            var result = await userDataProvider.UserLoginAsync(request);
            return mapper.Map<LoginResult>(result);
        }
    }
}
