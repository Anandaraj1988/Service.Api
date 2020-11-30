using System;

namespace ServiceApi.DataAccess.Model
{
    public class CreateDomainRequest
    {
        public string Name { get; set; }
        public Guid ApiKey { get; set; }
    }
}
