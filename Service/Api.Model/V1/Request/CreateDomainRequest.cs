using System;

namespace ServiceApi.Api.Model.V1
{
    public class CreateDomainRequest
    {
        public string Name { get; set; }
        public Guid ApiKey { get; set; }
        public Guid Domain { get; set; } = Guid.Empty;
    }
}
