using Firebase.Database;
using Firebase.Database.Offline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wayki.Models;
using Xamarin.Forms;

namespace Wayki
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var auth = "AIzaSyCDomtnaJvXsNPegB12MtBQUISekzqf1Eg"; // your app secret
                var firebaseClient = new FirebaseClient(
                  "https://wayki-14ad3.firebaseio.com/"
                  //new FirebaseOptions
                  //{
                  //    AuthTokenAsyncFactory = () => Task.FromResult(auth)
                  //}
                  );
                var messagesDb = firebaseClient.Child("dinosaurs").AsRealtimeDatabase<LoginInput>();
                messagesDb.Post(new LoginInput()
                {
                    Password = "444",
                    UsernameOrEmailAddress = "45545"
                });
         
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
