namespace ServiceApi.Api.Model.V1
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public int UserRole { get; set; }
    }
}
