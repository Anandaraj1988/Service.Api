namespace ServiceApi.DataAccess.Model
{
    public class LoginResult
    {
        public bool IsAuthenticated { get; set; }
        public string UserID { get; set; }
        public string AccessToken { get; set; }
    }
}
