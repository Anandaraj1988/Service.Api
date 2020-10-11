namespace ServiceApi.Api.Model.V1
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
    }
}
