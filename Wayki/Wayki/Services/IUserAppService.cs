using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wayki.Models;

namespace Wayki.Services
{
    public interface IUserAppService
    {
        Task<HttpResponseMessage> Login(LoginInput input);
    }
}
