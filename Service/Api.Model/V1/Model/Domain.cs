using System;

namespace ServiceApi.Api.Model.V1
{
    public class Domain
    {
        public Guid DomainID { get; set; }
        public string Name { get; set; }
        public Guid ApiKey { get; set; }
    }
}
