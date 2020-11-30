using System;

namespace ServiceApi.DataAccess.Model
{
    public class Domain
    {
        public Guid DomainID { get; set; }
        public string Name { get; set; }
        public Guid ApiKey { get; set; }
    }
}
