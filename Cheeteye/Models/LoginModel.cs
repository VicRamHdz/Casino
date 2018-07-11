using System;
namespace Cheeteye.Models
{
    public class LoginModel : BaseModel
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public UserProfileInfoModel UserProfile { get; set; }
    }
}
