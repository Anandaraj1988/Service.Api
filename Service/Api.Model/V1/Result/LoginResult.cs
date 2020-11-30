using System;

namespace ServiceApi.Api.Model.V1
{
    public class LoginResult
    {
        public Guid UserID { get; set; }
        public string AccessToken { get; set; }
        public int UserRole { get; set; }
    }
}
