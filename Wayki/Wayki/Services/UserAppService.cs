using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Offline;
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
        private static string ApiKey = "AIzaSyBWd4FgD-HUNCjyIzTxPLmtveX9LA0F3Vc";
        private static string Url = "https://wayki-14ad3.firebaseio.com/";
        public static UserInput UserCurrent;
        public static LoginInput UserLoing;
        public async Task<User> Login(LoginInput input)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(input.UsernameOrEmailAddress, input.Password);
            var firebase = new FirebaseClient(Url,
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken)
              });
            return a.User;
        }

        public async Task<User> AddOrUpdate(UserInput input)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var response = await auth.CreateUserWithEmailAndPasswordAsync(input.EmailAddress, input.Password, input.Name, false);
            var firebaseClient = new FirebaseClient(Url);
            var messagesDb = firebaseClient.Child("User/" + response.User.FederatedId).AsRealtimeDatabase<UserInput>();
            messagesDb.Post(new UserInput()
            {
                Name = input.Name,
                Dni = input.Dni,
                UserName = input.EmailAddress,
                IsActive = true,
                Surname = input.Surname,
                PhoneNumber = input.PhoneNumber,
                EmailAddress = input.EmailAddress,
            });

            return response.User;
        }
    }
}
