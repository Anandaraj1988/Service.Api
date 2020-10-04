using System.ComponentModel.DataAnnotations;

namespace ServiceApi.Api.Model.V1
{
    public class Enum
    {
        public enum UserRole
        {
            [Display(Name = "Admin", Description = "Admin")]
            Admin = 100,
            [Display(Name = "Staff", Description = "Staff")]
            Staff = 101,
            [Display(Name = "Reader", Description = "Reader")]
            Reader = 102
        }
    }
}
