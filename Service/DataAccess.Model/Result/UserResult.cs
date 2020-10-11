using System;

namespace ServiceApi.DataAccess.Model
{
    public class UserResult
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public int UserRole { get; set; }
        public string DomainName { get; set; }
        public Guid ApiKey { get; set; }
    }
}
