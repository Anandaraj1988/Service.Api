using AutoMapper;
using System.Threading.Tasks;
using System;

namespace ServiceApi.Business.Implementation
{
    using Api.Model.V1;
    using Business.Interface;
    using DataAccess.Interface;

    public class DomainDataService : IDomainDataService
    {
        private readonly IMapper mapper;
        private readonly IDomainDataProvider domainDataProvider;

        public DomainDataService(IMapper _Mapper, IDomainDataProvider _DomainDataProvider)
        {
            mapper = _Mapper;
            domainDataProvider = _DomainDataProvider;
        }

        public async Task<Domain> CreateDomainAsync(string name, Guid apiKey)
        {
            var domain = await domainDataProvider.CreateDomainAsync(name, apiKey);
            return mapper.Map<Domain>(domain);
        }
    }
}
