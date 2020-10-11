using System;

namespace ServiceApi.Api.Model.V1
{
    public class LoginResult
    {
        public bool IsAuthenticated { get; set; }
        public Guid UserID { get; set; }
        public Guid AccessToken { get; set; }
        public int UserRole { get; set; }
        public string UserRoleName { get; set; }
    }
}
