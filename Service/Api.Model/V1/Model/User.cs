using System;
using System.Runtime.Serialization;

namespace ServiceApi.Api.Model.V1
{
    public class User
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string Email { get; set; }
        public string Domain { get; set; }
    }
}
