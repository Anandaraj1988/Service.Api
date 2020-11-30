using AutoMapper;
using System.Threading.Tasks;

namespace ServiceApi.Business.Implementation
{
    using Api.Model.V1;
    using Business.Interface;
    using DataAccess.Interface;
    using Data = DataAccess.Model;

    public class DomainDataService : IDomainDataService
    {
        private readonly IMapper mapper;
        private readonly IDomainDataProvider domainDataProvider;

        public DomainDataService(IMapper _Mapper, IDomainDataProvider _DomainDataProvider)
        {
            mapper = _Mapper;
            domainDataProvider = _DomainDataProvider;
        }

        public async Task<Domain> CreateDomainAsync(CreateDomainRequest createDomainRequest)
        {
            var request = mapper.Map<Data.CreateDomainRequest>(createDomainRequest);
            var domain = await domainDataProvider.CreateDomainAsync(request);
            return mapper.Map<Domain>(domain);
        }
    }
}
