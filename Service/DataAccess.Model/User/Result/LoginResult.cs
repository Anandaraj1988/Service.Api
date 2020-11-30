using System;

namespace ServiceApi.DataAccess.Model
{
    public class LoginResult
    {
        public Guid UserID { get; set; }
        public string AccessToken { get; set; }
        public int UserRole { get; set; }
    }
}
