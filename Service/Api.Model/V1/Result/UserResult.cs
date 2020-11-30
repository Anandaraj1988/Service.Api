using System;

namespace ServiceApi.Api.Model.V1
{
    public class UserResult
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public int UserRole { get; set; }
        public string UserRoleName { get; set; }
        public string DomainName { get; set; }
        public string AccessToken { get; set; }
    }
}
