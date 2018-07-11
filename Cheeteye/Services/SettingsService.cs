using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cheeteye.Models;

namespace Cheeteye.Services
{
    public class SettingsService : BaseProvider
    {
        public async Task<ResponseResult<List<LanguageModel>>> GetLanguages()
        {
            var endpoint = "Languages?code=wfIhNalXGmYdhvPklexRKHcWaqGiLXZWrX4hlbYVzfJMfsVdaLkcmw==";
            var result = await GetAsync<List<LanguageModel>>(endpoint);
            return result;
        }

        public async Task<ResponseResult<List<TimeZoneModel>>> GetTimeZones()
        {
            var endpoint = "TimeZones?code=iojuzkYvcgju4rnp2nGaQ6fl1UHMXDn/o22H7vQcJK7WCj85hwavNA==";
            var result = await GetAsync<List<TimeZoneModel>>(endpoint);
            return result;
        }

        public async Task<ResponseResult<UserProfileInfoModel>> UpdateSettings(UserProfileInfoModel UserProfileInfo)
        {
            var p = new
            {
                UserProfileId = UserProfileInfo.UserProfileId,
                LanguageId = UserProfileInfo.LanguageId,
                TimeZoneId = UserProfileInfo.TimeZoneId
            };
            var endpoint = "AppSettings?code=lKfRkHm2M7TVmH36aZhVfgwv8Fp2OyFO6a7aT1Fp1TlNvVSM7W6v7w==";
            var result = await PostAsync<object, UserProfileInfoModel>(endpoint, p);
            return result;
        }
    }
}
