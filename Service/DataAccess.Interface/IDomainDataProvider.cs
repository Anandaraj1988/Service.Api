using System.Threading.Tasks;
using System;

namespace ServiceApi.DataAccess.Interface
{
    using DataAccess.Model;

    public interface IDomainDataProvider
    {
        Task<Domain> CreateDomainAsync(string name, Guid apiKey);
    }
}
