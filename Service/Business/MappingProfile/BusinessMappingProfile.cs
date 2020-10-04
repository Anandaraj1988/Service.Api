using AutoMapper;
using Microsoft.OpenApi.Extensions;

namespace ServiceApi.Business.MappingProfile
{
    using Data = DataAccess.Model;
    using BusinessV1 = Api.Model.V1;
    public class BusinessMappingProfile : Profile
    {
        public BusinessMappingProfile()
        {
            this.ForAllMaps((typeMap, mapConfig) => mapConfig.PreserveReferences());

            #region UserDataService
            this.GetUserMapping();
            this.GetLoginResultMapping();
            #endregion
        }

        private void GetUserMapping()
        {
            this.CreateMap<Data.User, BusinessV1.User>()
                .ForMember(d => d.UserID, o => o.MapFrom(s => s.UserID))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.EmailID))
                .ForMember(d => d.Domain, o => o.MapFrom(s => s.Domain))
                .ForMember(d => d.UserRole, o => o.MapFrom(s => ((BusinessV1.Enum.UserRole)s.UserRole).GetDisplayName()));
        }

        private void GetLoginResultMapping()
        {
            this.CreateMap<Data.LoginResult, BusinessV1.LoginResult>()
                .ForMember(d => d.UserID, o => o.MapFrom(s => s.UserID))
                .ForMember(d => d.IsAuthenticated, o => o.MapFrom(s => s.IsAuthenticated));
        }
    }
}
