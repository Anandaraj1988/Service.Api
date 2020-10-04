using System;

namespace ServiceApi.DataAccess.Model
{
    public class User
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public int UserRole { get; set; }
        public string EmailID { get; set; }
    }
}
