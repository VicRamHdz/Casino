using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cheeteye.Models;

namespace Cheeteye.Services
{
    public class NotificationsService : BaseProvider
    {
        public async Task<ResponseResult<List<NotificationModel>>> GetNotifications()
        {
            var endpoint = "NotificationsCatalog?code=LBaYSwIjBDbhVYDSCb9BPagYtOdMYU68cunn7KaqNbe3rsdvXW4Lfg==";
            var result = await GetAsync<List<NotificationModel>>(endpoint);
            return result;
        }
    }
}
