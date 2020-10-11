using System.Threading.Tasks;
using System;

namespace ServiceApi.Business.Interface
{
    using Api.Model.V1;

    public interface IDomainDataService
    {
        Task<Domain> CreateDomainAsync(string name, Guid apiKey);
    }
}
