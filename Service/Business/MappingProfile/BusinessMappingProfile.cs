using AutoMapper;
using Microsoft.OpenApi.Extensions;
using ServiceApi.Business.Common;
using System;

namespace ServiceApi.Business.MappingProfile
{
    using Data = DataAccess.Model;
    using Model = Api.Model.V1;
    public class BusinessMappingProfile : Profile
    {
        public BusinessMappingProfile()
        {
            this.ForAllMaps((typeMap, mapConfig) => mapConfig.PreserveReferences());

            this.CreateMap<Model.CreateDomainRequest, Data.CreateDomainRequest>();

            this.CreateMap<Model.CreateUserRequest, Data.CreateUserRequest>()
                .ForMember(d => d.Password, o => o.MapFrom(s => (!string.IsNullOrEmpty(s.Password)) ? Helper.EncryptPassword(s.Password) : string.Empty))
                .ForMember(d => d.UserID, o => o.Ignore())
                .ForMember(d => d.EmailID, o => o.Ignore());

            this.CreateMap<Model.LoginRequest, Data.LoginRequest>()
                .ForMember(d => d.Password, o => o.MapFrom(s => (!string.IsNullOrEmpty(s.Password)) ? Helper.EncryptPassword(s.Password) : string.Empty));

            this.CreateMap<Data.Domain, Model.Domain>();

            this.CreateMap<Data.UserResult, Model.UserResult>()
                .ForMember(d => d.UserRoleName, o => o.MapFrom(s => ((Model.Enum.UserRole)s.UserRole).GetDisplayName()));

            this.CreateMap<Data.LoginResult, Model.LoginResult>();

            this.CreateMap<Data.Domain, Model.Domain>();
        }
    }
}
