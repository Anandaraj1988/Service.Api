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

            #region DomainDataService
            this.GetDomainMapping();
            #endregion
        }

        private void GetUserMapping()
        {
            this.CreateMap<Data.UserResult, BusinessV1.UserResult>()
                .ForMember(d => d.UserID, o => o.MapFrom(s => s.UserID))
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.UserName))
                .ForMember(d => d.UserRole, o => o.MapFrom(s => s.UserRole))
                .ForMember(d => d.UserRoleName, o => o.MapFrom(s => ((BusinessV1.Enum.UserRole)s.UserRole).GetDisplayName()))
                .ForMember(d => d.DomainName, o => o.MapFrom(s => s.DomainName))
                .ForMember(d => d.ApiKey, o => o.MapFrom(s => s.ApiKey));
        }

        private void GetLoginResultMapping()
        {
            this.CreateMap<Data.LoginResult, BusinessV1.LoginResult>()
                .ForMember(d => d.UserID, o => o.MapFrom(s => s.UserID))
                .ForMember(d => d.IsAuthenticated, o => o.MapFrom(s => s.IsAuthenticated))
                .ForMember(d => d.AccessToken, o => o.MapFrom(s => s.AccessToken));
        }

        private void GetDomainMapping()
        {
            this.CreateMap<Data.Domain, BusinessV1.Domain>()
                .ForMember(d => d.DomainID, o => o.MapFrom(s => s.DomainID))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.ApiKey, o => o.MapFrom(s => s.ApiKey));
        }
    }
}
