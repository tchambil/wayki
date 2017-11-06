using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wayki.Models;

namespace Wayki.Services
{
    public class UserAppService : IUserAppService
    {
        public static UserInput UserCurrent;
        public static LoginInput UserLoing;
        public Task<HttpResponseMessage> Login(LoginInput input)
        {
            throw new NotImplementedException();
        }
    }
}
