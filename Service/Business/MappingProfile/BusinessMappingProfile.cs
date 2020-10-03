using AutoMapper;

namespace ServiceApi.Business.MappingProfile
{
    public class BusinessMappingProfile : Profile
    {
        public BusinessMappingProfile()
        {
            this.ForAllMaps((typeMap, mapConfig) => mapConfig.PreserveReferences());
        }
    }
}
