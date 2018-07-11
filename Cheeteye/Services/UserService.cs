using System;
using System.Threading.Tasks;
using Cheeteye.Models;

namespace Cheeteye.Services
{
    public class UserService : BaseProvider
    {
        public async Task<ResponseResult<EnrollResponseModel>> Enroll(int MembershipNumber, string FirstName, string LastName, string Email)
        {
            var p = new { MembershipNumber = MembershipNumber, FirstName = FirstName, LastName = LastName, Email = Email };
            var endpoint = "Enroll?code=5nDETaIVStB176JKHoOtyBtTRIZ3oPzSoZuvi7/hRXtzdj8slk1kww==";
            var result = await PostAsync<object, EnrollResponseModel>(endpoint, p);
            return result;
        }

        public async Task<ResponseResult<UserProfileInfoModel>> CreateAccount(string Email, string Pin, string Password)
        {
            var p = new { Email = Email, Pin = Pin, Password = Password };
            var endpoint = "CreateAccount?code=Puezq17mZD3jhihAbd3ostGajIdSOBNkzUJjnjwlQG1YOP8EioPFGw==";
            var result = await PostAsync<object, UserProfileInfoModel>(endpoint, p);
            return result;
        }

        public async Task<ResponseResult<LoginModel>> Login(string Email, string Password)
        {
            var p = new { Email = Email, Password = Password };
            var endpoint = "Login?code=nUn8a1KBiSRpKokpHHTC0h9xkaotNwe2mpV7FrF3WF4xYK3HjqUBJg==";
            var result = await PostAsync<object, LoginModel>(endpoint, p);
            return result;
        }

        public async Task<ResponseResult<UserProfileInfoModel>> ForgotPassword(string Email)
        {
            var p = new { Email = Email };
            var endpoint = "ForgotPassword?code=nUn8a1KBiSRpKokpHHTC0h9xkaotNwe2mpV7FrF3WF4xYK3HjqUBJg==";
            var result = await PostAsync<object, UserProfileInfoModel>(endpoint, p);
            return result;
        }

        public async Task<ResponseResult<UserProfileInfoModel>> UpdateProfile(UserProfileInfoModel UserProfileInfo)
        {
            var p = new
            {
                UserProfileId = UserProfileInfo.UserProfileId,
                FirstName = UserProfileInfo.FirstName,
                LastName = UserProfileInfo.LastName,
                Email = UserProfileInfo.Email
            };
            var endpoint = "PersonalSettings?code=nUn8a1KBiSRpKokpHHTC0h9xkaotNwe2mpV7FrF3WF4xYK3HjqUBJg==";
            var result = await PostAsync<object, UserProfileInfoModel>(endpoint, p);
            return result;
        }
    }
}
