using System;

namespace ServiceApi.DataAccess.Model
{
    public class AuthorizedUserResult
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public int UserRole { get; set; }
        public string AccessToken { get; set; }
    }
}
